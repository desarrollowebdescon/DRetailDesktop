using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace DRtail
{
    public partial class frmMenu : Form
    {

        #region "Variables"
        public DatosUsuario dtosUsuarios;
        List<DatosArticulos> items;
        List<DatosSocios> socios;
        public string codClienteSelec = "";
        int numArticulos = 0;
        double importeTotal = 0;

        #endregion
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnCotizacion_Click(object sender, EventArgs e)
        {
            //MostrarPanel(pnlCotizacion, btnCotizacion);
        }
        private void pnlCotizacion_VisibleChanged(object sender, EventArgs e)
        {
            //OcultarPanel(pnlCotizacion, btnCotizacion);
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            this.Text = this.Text;// + " - " + dtos.nombreC;
            frmMensaje mensaje = new frmMensaje();
            mensaje.lblMensaje.Text = mensaje.lblMensaje.Text;// + " " + dtos.nombreC + "!!!";
            mensaje.menu = this;
            mensaje.ShowDialog();
            //ObtenerArticulos();
            //ObtenerSocios();
            //AutoCompletar(txtProducto, "DatosArticulos");
            //AutoCompletar(txtCliente, "DatosSocios");
        }

        private void lnkLblBuscarCliente_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmClientes clientes = new frmClientes();
            clientes.dtosSocios = socios;
            clientes.menu = this;
            clientes.ShowDialog();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            //MostrarPanel(pnlClientes, btnClientes);
            //MostrarSubPanel(pnlClientesBusc);

            //if (dgvClientes.DataSource == null)
            //{
            //    DataTable dtResSocios = CrearDTSocios();

            //    dgvClientes.DataSource = dtResSocios;

            //    foreach (DataGridViewColumn col in dgvClientes.Columns)
            //    {
            //        col.HeaderText = dtResSocios.Columns[col.HeaderText].Caption;
            //    }

            //    dgvClientes.Sort(dgvClientes.Columns[0], ListSortDirection.Ascending);
            //}

        }

        private void pnlClientes_VisibleChanged(object sender, EventArgs e)
        {
            //OcultarPanel(pnlClientes, btnClientes);
            //pnlClientesBusc.Visible = true;
            //pnlClientesCrea.Visible = false;
        }

        private void btnActualizarCliente_Click(object sender, EventArgs e)
        {
           // MostrarSubPanel(pnlClientes, pnlClientesAct, btnActualizarCliente);
        }

        public void MostrarSubPanel(Panel panelPadre, Panel panelHijo = null, Button botton = null)
        {
            foreach (Control control in panelPadre.Controls)
            {
                if (control is Panel)
                    control.Visible = false;
            }

            if (botton != null)
                botton.BackColor = Color.LightBlue;
            if (panelHijo != null)
                panelHijo.Visible = true;
        }

        public void OcultarSubPanel(Panel panel, Button botton)
        {
            if (panel.Visible == false)
                botton.BackColor = Color.White;
        }

        private void pnlClientesAct_VisibleChanged(object sender, EventArgs e)
        {
           // OcultarSubPanel(pnlClientesCrea, btnCrearCliente);
        }

        private void pnlClientesBusc_VisibleChanged(object sender, EventArgs e)
        {
            //if (pnlClientesBusc.Visible == true)
            //{
            //    btnActualizarCliente.BackColor = btnCrearCliente.BackColor = btnProspectos.BackColor = Color.White;
            //}
        }

        private void pnlClientesAct_VisibleChanged_1(object sender, EventArgs e)
        {
            //OcultarSubPanel(pnlClientesAct, btnActualizarCliente);
        }

        private void btnCrearCliente_Click(object sender, EventArgs e)
        {
            //MostrarSubPanel(pnlClientes, pnlClientesCrea, btnCrearCliente);
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
          //  AgregarArticuloDGV();
        }

        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {

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
                foreach (DatosSocios s in socios)
                {
                    stringCol.Add(s.CodigoCliente);
                }
            }
            return stringCol;
        }

        

        #region "Metodos Descon"

        #endregion

       

        private void pnlProductos_VisibleChanged(object sender, EventArgs e)
        {
           // OcultarPanel(pnlProductos, btnProductos);
        }

        private void btnEntradasProd_Click(object sender, EventArgs e)
        {

        }

        private void btnSalidasProd_Click(object sender, EventArgs e)
        {

        }

        private void btnInventario_Click(object sender, EventArgs e)
        {

        }

        private void btnFacturas_Click(object sender, EventArgs e)
        {

        }

        private void btnCorte_Click(object sender, EventArgs e)
        {

        }

        private void btnReportes_Click(object sender, EventArgs e)
        {

        }

        private void btnPuntos_Click(object sender, EventArgs e)
        {

        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {

        }

        private void btnVenta_Click(object sender, EventArgs e)
        {

        }
    }
}
