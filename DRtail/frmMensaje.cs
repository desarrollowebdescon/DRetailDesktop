using System;
using System.Windows.Forms;

namespace DRtail
{
    public partial class frmMensaje : Form
    {
        public frmMensaje()
        {
            InitializeComponent();
        }

        public frmMenu menu;

        private void frmMensaje_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
