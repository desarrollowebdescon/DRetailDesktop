
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DRtail
{
    public partial class frmMenuLateral : Form
    {

        #region "Variables"
        public DatosUsuario dtosUsuarios;
        List<DatosArticulos> items;
        public List<DatosArticulos> itemsCotizacion = new List<DatosArticulos>();
        public List<DatosArticulos> itemsPedido = new List<DatosArticulos>();
        List<DatosSocios> socios;
        public string codClienteSelec = "";
        int numArticulos = 0;
        double importeTotal = 0;
        string formID = String.Empty;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        private int pnlMenuLat = 315;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion
        public frmMenuLateral()
        {
            InitializeComponent();
            SelectedLineMenu();
            btnRestore.Visible = true;
            btnMaxim.Visible = false;
            Rectangle wa = Screen.FromControl(this).WorkingArea;
            this.MaximumSize = new Size(wa.Width, wa.Height);
            Servicios.menuLateral = this;
        }

        private void btnClientesMenu_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(new Clientes());
            SelectedLineMenu();
            pnlLineClientes.Visible = true;
            this.LblTitle.Text = "CLIENTES";


        }
        private void btnCotizaMenu_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(new Cotizaciones(""));
            SelectedLineMenu();
            pnlLineCotizaciones.Visible = true;
            this.LblTitle.Text = "COTIZACIONES";
        }
        private void btnPedidosMenu_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(new Pedidos("",""));
            SelectedLineMenu();
            pnlLinePedidos.Visible = true;
            this.LblTitle.Text = "PEDIDOS";
        }
        private void btnProdMenu_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(new Productos());
            SelectedLineMenu();
            pnlLineProductos.Visible = true;
            this.LblTitle.Text = "PRODUCTOS";
        }
        public void AgregarArticuloCotizacion(DatosArticulos da)
        {
            itemsCotizacion.Add(da);
        }
        public List<DatosArticulos> ObtenerArticulosCotizacion()
        {
            return itemsCotizacion;
        }

        public void AgregarArticuloPedido(DatosArticulos da)
        {
            itemsPedido.Add(da);
        }
        public List<DatosArticulos> ObtenerArticulosPedido()
        {
            return itemsPedido;
        }
        private void btnInvenMenu_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(new Inventario());
            SelectedLineMenu();
            pnlLineInventario.Visible = true;
            this.LblTitle.Text = "INVENTARIO";
        }

        private void btnFacturasMenu_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(new Facturacion());
            SelectedLineMenu();
            pnlLineFacturas.Visible = true;
            this.LblTitle.Text = "FACTURAS";
        }

        private void btnReportesMenu_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(new Reportes());
            SelectedLineMenu();
            pnlLineReportes.Visible = true;
            this.LblTitle.Text = "REPORTES";
        }
        private void btnCorteMenu_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(new Corte());
            SelectedLineMenu();
            pnlLineCorte.Visible = true;
            this.LblTitle.Text = "CORTES";
        }
        private void btnPLealMenu_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(new PLealtad());
            SelectedLineMenu();
            pnlLinePLealtad.Visible = true;
        }
        private void btnConfigMenu_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(new Configuraciones());
            SelectedLineMenu();
            pnlLineConfiguracion.Visible = true;
            this.LblTitle.Text = "CONFIGURACIONES";
        }



        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            this.Text = this.Text;// + " - " + dtos.nombreC;
            frmMensaje mensaje = new frmMensaje();
            mensaje.lblMensaje.Text = mensaje.lblMensaje.Text;// + " " + dtos.nombreC + "!!!";
                                                              // mensaje.menu = this;
            mensaje.ShowDialog();

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (pnlMenuLateral.Width == pnlMenuLat)
            {
                pnlMenuLateral.Width = 90;
                MiniButons();
            }
            else
            {
                pnlMenuLateral.Width = pnlMenuLat;
                MaxiButton();
            }
        }

        private void MaxiButton()
        {
            Size minS = new Size(296, 60);
            pnlBoxMenuClientes.Size = minS;
            pnlBoxMenuCotizaciones.Size = minS;
            pnlBoxMenuCSesion.Size = minS;
            pnlBoxMenuConfiguracion.Size = minS;
            pnlBoxMenuPLealtad.Size = minS;
            pnlBoxMenuPedidos.Size = minS;
            pnlBoxMenuCorte.Size = minS;
            pnlBoxMenuReportes.Size = minS;
            pnlBoxMenuFacturas.Size = minS;
            pnlBoxMenuInventario.Size = minS;
            pnlBoxMenuProductos.Size = minS;
            picMenuLogo.Visible = true;
        }

        private void MiniButons()
        {
            Size minS = new Size(50, 60);
            pnlBoxMenuClientes.Size = minS;
            pnlBoxMenuCotizaciones.Size = minS;
            pnlBoxMenuCSesion.Size = minS;
            pnlBoxMenuConfiguracion.Size = minS;
            pnlBoxMenuPLealtad.Size = minS;
            pnlBoxMenuPedidos.Size = minS;
            pnlBoxMenuCorte.Size = minS;
            pnlBoxMenuReportes.Size = minS;
            pnlBoxMenuFacturas.Size = minS;
            pnlBoxMenuInventario.Size = minS;
            pnlBoxMenuProductos.Size = minS;
            picMenuLogo.Visible = false;



        }



        private void btnVenta_Click(object sender, EventArgs e)
        {

        }

        private void btnCSesionMenu_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        public void SelectedLineMenu()
        {
            pnlLineClientes.Visible = false;
            pnlLineCotizaciones.Visible = false;
            pnlLinePedidos.Visible = false;
            pnlLineProductos.Visible = false;
            pnlLineInventario.Visible = false;
            pnlLineFacturas.Visible = false;
            pnlLineReportes.Visible = false;
            pnlLineCorte.Visible = false;
            pnlLinePLealtad.Visible = false;
            pnlLineConfiguracion.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            //this.Size = new Size(1200,780);
            btnRestore.Visible = false;
            btnMaxim.Visible = true;

        }

        private void btnMaxim_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnRestore.Visible = true;
            btnMaxim.Visible = false;
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            btnRestore.Visible = false;
            btnMaxim.Visible = true;
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void picMenuLogo_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://cafeetrusca.com");
        }
    }
}
