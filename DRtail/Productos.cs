using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DRtail
{
    public partial class Productos : UserControl
    {

        List<DatosArticulos> items;
        public Productos()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            getData();
        }

        private void getData()
        {
            
            items = Servicios.GetArticulos();
            SetDataGrid(items);
        }
       

        private void SetDataGrid(List<DatosArticulos> articulos)
        {
           
            foreach (DatosArticulos sa in articulos)
            {

                Random rnm = new Random();
                int value = rnm.Next(1000);
                string serie = value.ToString("000");

                bcdgproductos.Rows.Add(sa.Codigo, sa.Descripcion, sa.Costo, sa.Impuesto,0, serie, sa.TotalStock);

            }
        }

        private void btnCerrarTraspaso_Click(object sender, EventArgs e)
        {
            pnlPUtr.Visible = false;
            bdgTraspaso.Rows.Clear();

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            pnlbusquedaArticulo.Visible = false;
            pnlbusquedaArticulo.BringToFront();
            dgBuscadorArticulo.Rows.Clear();
        }

        private void txtBuscarArtTraspaso_KeyUp(object sender, KeyEventArgs e)
        {
            List<DatosArticulos> tempItems = items;
            dgBuscadorArticulo.Rows.Clear();
            tempItems = tempItems.Where(i => (i.Codigo.Contains(txtBuscarArtTraspaso.Text)
                                           || (i.Descripcion != null 
                                                ? i.Descripcion
                                                : "").Contains(txtBuscarArtTraspaso.Text))
                                        ).ToList();
            
            foreach(DatosArticulos da in tempItems)
            {
                dgBuscadorArticulo.Rows.Add(da.Codigo,da.Descripcion);
            }
            
        }

        private void btnAgregarBusqueda_Click(object sender, EventArgs e)
        {
            string codigo =   dgBuscadorArticulo.SelectedRows[0].Cells[0].Value.ToString();
            txtArticulo.Text = codigo;
            pnlbusquedaArticulo.Visible = false;
            dgBuscadorArticulo.Rows.Clear();
        }

        private void bbtnSolTraspaso_Click(object sender, EventArgs e)
        {
            txtArticulo.Text= bcdgproductos.SelectedRows[0].Cells[0].Value.ToString();
            pnlPUtr.Visible = true;
            pnlPUtr.BringToFront();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            foreach (DatosArticulos da in items)
            {
                dgBuscadorArticulo.Rows.Add(da.Codigo, da.Descripcion);
            }

            pnlbusquedaArticulo.Visible = true;
            
            pnlbusquedaArticulo.BringToFront();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DatosArticulos ds = items.Where(i => i.Codigo == txtArticulo.Text).FirstOrDefault();
            if(ds  != null)
            {
                bdgTraspaso.Rows.Add(ds.Codigo, ds.Descripcion, numCantidad.Value, ds.TotalStock, 0);
                txtArticulo.Text = "";
                numCantidad.Value = 0;
            }
            
        }

        private void btnCreatTraspaso_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se ha realizado la petición correctamente");

            pnlPUtr.Visible = false;
            bdgTraspaso.Rows.Clear();

        }

        private void btxtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            List<DatosArticulos> tempAr = new List<DatosArticulos>(); ;
            bcdgproductos.Rows.Clear();

            tempAr = items.Where(i => ((i.Descripcion != null
                                            ? i.Descripcion
                                            : "").Contains(btxtBuscar.Text)
                                    || i.Codigo.Contains(btxtBuscar.Text)
                                )).ToList();
           

            foreach (DatosArticulos sa in tempAr)
            {
                Random rnm = new Random();
                int value = rnm.Next(1000);
                string serie = value.ToString("000");

                bcdgproductos.Rows.Add(sa.Codigo, sa.Descripcion, sa.Costo, sa.Impuesto,0 , serie, sa.TotalStock);

            }
        }

        private void btxtBuscar_Enter(object sender, EventArgs e)
        {
            lblHeadBuscar.Visible = true;
        }

        private void btxtBuscar_Leave(object sender, EventArgs e)
        {

            if(btxtBuscar.Text.Length > 0)
            {
                lblHeadBuscar.Visible = true;
            }
            else
            {
                lblHeadBuscar.Visible = false;
            }

        }

        private void bbtnAgregarPedido_Click(object sender, EventArgs e)
        {
          
            frmMenuLateral parent =(frmMenuLateral)this.ParentForm;

            DatosArticulos da = new DatosArticulos();
            DataGridViewRow  dgvr = bcdgproductos.SelectedRows[0];
            da.Codigo = dgvr.Cells[0].Value.ToString();
            da.Descripcion = dgvr.Cells[1].Value.ToString();
            da.Costo  =  double.Parse(dgvr.Cells[2].Value.ToString());
            da.Impuesto = double.Parse(dgvr.Cells[3].Value.ToString());
            da.Lote = double.Parse(dgvr.Cells[4].Value.ToString());
            da.Serie = double.Parse(dgvr.Cells[5].Value.ToString());
            da.TotalStock = double.Parse(dgvr.Cells[6].Value.ToString());

            parent.AgregarArticuloPedido(da);

        }

        private void btnAgregarCotizacion_Click(object sender, EventArgs e)
        {
            frmMenuLateral parent = (frmMenuLateral)this.ParentForm;

            DatosArticulos da = new DatosArticulos();
            DataGridViewRow dgvr = bcdgproductos.SelectedRows[0];
            da.Codigo = dgvr.Cells[0].Value.ToString();
            da.Descripcion = dgvr.Cells[1].Value.ToString();
            da.Costo = double.Parse(dgvr.Cells[2].Value.ToString());
            da.Impuesto = double.Parse(dgvr.Cells[3].Value.ToString());
            da.Lote = double.Parse(dgvr.Cells[4].Value.ToString());
            da.Serie = double.Parse(dgvr.Cells[5].Value.ToString());
            da.TotalStock = (dgvr.Cells[6].Value.ToString() != null ) ?double.Parse(dgvr.Cells[6].Value.ToString()): 0;

            parent.AgregarArticuloCotizacion(da);
        }
    }
}
