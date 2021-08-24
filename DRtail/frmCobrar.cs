using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DRtail
{
    public partial class frmCobrar : Form
    {

        public frmMenu menu2;
        public double totalVenta = 0;

        public frmCobrar()
        {
            InitializeComponent();
        }

        private void frmCobrar_Load(object sender, EventArgs e)
        {
            lblCobro.Text = totalVenta.ToString("C");
        }

        private void btnCredito_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cerrar();
        }

        private void frmCobrar_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        void Cerrar()
        {
            this.Dispose();
        }

        private void numUpDwPago_ValueChanged(object sender, EventArgs e)
        {
            lblCambio.Text = (double.Parse(numUpDwPago.Value.ToString()) - totalVenta).ToString("C");
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if ((double.Parse(numUpDwPago.Value.ToString()) - totalVenta) >= 0)
            {

            }
            else
            {
                MessageBox.Show("No se ha realizado el cobro completo!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmCobrar_KeyDown(object sender, KeyEventArgs e)
        {

        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                if ((double.Parse(numUpDwPago.Value.ToString()) - totalVenta) >= 0)
                {
                    MessageBox.Show("", "DRatil - Imprimir Ticket");
                   // menu2.btnCobradoCotizaciones.Visible = true;
                }
                else
                {
                    MessageBox.Show("No se ha realizado el cobro completo!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (keyData == Keys.Escape)
            {
                Cerrar();
            }
            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }


    }
}
