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
    public partial class Facturacion : UserControl
    {

        #region "Variables"
        public List<DatosSocios> dtosSocios;
        List<DatosArticulos> items;
        List<DatosFactura> datosFacturas;
        public int ordenDGV = 0;
        public string codClienteSelec = "";
        DataTable dtSocios = new DataTable();
        int numArticulos = 0;
        double importeTotal = 0;
        string tempDescuento = "";
        string tempDescuentoOld = "";
        string docEntrySeleccionado = "";
        #endregion

        
        public Facturacion()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            GetDatos();
        }

        private void GetDatos()
        {
            datosFacturas = Servicios.getFacturas();

            foreach(DatosFactura df in datosFacturas)
            {
                bdgFacturas.Rows.Add(df.NoFactura, df.Cliente, df.Nombre, df.FechaEntrega, df.TotalFacturado, df.Estatus,"...");
            }

        }

        private void txtBuscarFactura_KeyUp(object sender, KeyEventArgs e)
        {

            List<DatosFactura> dfList = datosFacturas;
            bdgFacturas.Rows.Clear();
            dfList = dfList.Where(df => 
                                    (df.Cliente.Contains(txtBuscarFactura.Text) ||
                                     df.NoFactura.Contains(txtBuscarFactura.Text) ||
                                     df.Nombre.ToString().Contains(txtBuscarFactura.Text)
                                    )
                                ).ToList();
            foreach (DatosFactura df in dfList)
            {
                bdgFacturas.Rows.Add(df.NoFactura, df.Cliente, df.Nombre, df.FechaEntrega, df.TotalFacturado, df.Estatus, "...");
            }

        }

       

        private void btnAccionesGPedido_Click(object sender, EventArgs e)
        {
            pnlPOAccion.Visible = false;
            pnlFGenerarFactura.Visible = true;
        }

        private void btnAccionesReimp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se ha mandado a imprimir correctamente");
        }

        private void btnFGenerarFacturaPago_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se ha generado correctamente su factura");
            pnlFGenerarFactura.Visible = false;
            pnlPOAcciones.Visible = false;

        }

        private void btnFpnlAClose_Click(object sender, EventArgs e)
        {
            pnlPOAcciones.Visible = false;
        }

        private void btnFpnlPagosClose_Click(object sender, EventArgs e)
        {
            pnlFGenerarFactura.Visible = false;
        }

        private void bdgFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            if(e.ColumnIndex == 4)
            {
                pnlPOAccion.Visible = true;
                pnlPOAcciones.Visible = true;
                lblNPedido.Text = bdgFacturas.Rows[e.RowIndex].Cells[0].Value.ToString();
                lblTotalFacturadoNum.Text = bdgFacturas.Rows[e.RowIndex].Cells[2].Value.ToString();
                lblEstatusNum.Text = bdgFacturas.Rows[e.RowIndex].Cells[3].Value.ToString();

            }
        }

        private void btnCerrarPU_Click(object sender, EventArgs e)
        {

            pnlPOAcciones.Visible = false;
            pnlFGenerarFactura.Visible = false;
        }

        void AutoCompletar(TextBox txtAutoCmpletar, string clase)
        {
            txtAutoCmpletar.AutoCompleteCustomSource = LoadAutoComplete(clase);
            txtAutoCmpletar.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtAutoCmpletar.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        public AutoCompleteStringCollection LoadAutoComplete(string clase)
        {
            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();

            if (clase == "DatosArticulos")
            {
                foreach (DatosArticulos i in items)
                {
                    stringCol.Add(i.Codigo);
                }
            }
            else if (clase == "DatosSocios")
            {
                foreach (DatosSocios s in dtosSocios)
                {
                    stringCol.Add(s.CodigoCliente);
                }
            }
            return stringCol;
        }

    }
}
