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
    public partial class Inventario : UserControl
    {

        List<DatosArticulos> items;
        public Inventario()
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

                bcdgproductos.Rows.Add(sa.Codigo, sa.Descripcion, sa.TotalStock, sa.TotalStock,0, 0, "...");

            }
        }

        private void btxtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            List<DatosArticulos> tempItems = items;
            bcdgproductos.Rows.Clear();
            tempItems = tempItems.Where(i => (i.Codigo.Contains(btxtBuscar.Text)
                                           || (i.Descripcion != null
                                                ? i.Descripcion
                                                : "").Contains(btxtBuscar.Text))
                                        ).ToList();

            SetDataGrid(tempItems);
        }

        private void bcdgproductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 6)
            {
                pnlPUAcciones.Visible = true;
                lblCodigoArticuloNum.Text = bcdgproductos.Rows[e.RowIndex].Cells[0].Value.ToString();
                lblNombreArtNum.Text = bcdgproductos.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void btnCerrarTraspaso_Click(object sender, EventArgs e)
        {
            pnlPUAcciones.Visible = false;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            pnlPUAcciones.Visible = false;
        }
    }
}
