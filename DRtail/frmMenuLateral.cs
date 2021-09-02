
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.WebSockets;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
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
        public string codigoSocioActivo = "";
        public string codClienteSelec = "";
        int numArticulos = 0;
        double importeTotal = 0;
        string formID = String.Empty;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        private int pnlMenuLat = 315;
        protected bool isDragging = false;
        protected Rectangle lastRectangle = new Rectangle();
        private Rectangle wa;
        bool IsLine = false;
        Socket socket = new Socket();


        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion
        public frmMenuLateral()
        {
            InitializeComponent();
            SelectedLineMenu("");
            
            Conectar();
            getLine();
            btnRestore.Visible = true;
            btnMaxim.Visible = false;
            wa = Screen.FromControl(this).WorkingArea;
            this.MaximumSize = new Size(wa.Width, wa.Height);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            

         

        }

        private void Conectar()
        {

            Task.Run(async() => 
            {
                await Socket.Conectar();
                
            });
           
           
            
        }

        private void getLine()
        {

            Task.Run(async () =>
            {
                
              
                while (true)
                {
                    IsLine =  await socket.getInLine();
                    if (IsLine)
                    {
                        pbSemaforo.BackgroundImage = Properties.Resources.semaforo_verde;
                    }
                    else
                    {
                        pbSemaforo.BackgroundImage = Properties.Resources.semaforo_rojo;
                    }
                    
                }
               


            });

           
        }
            

      

        private const int cGrip = 16;      // Grip size
        private const int cCaption = 32;   // Caption bar height;

        protected override void OnPaint( PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(ClientSize.Width - cGrip, ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
            
        }

        protected override void WndProc(ref Message m)
        {
            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg)
            {
                case 0x0084/*NCHITTEST*/ :
                    base.WndProc(ref m);

                    if ((int)m.Result == 0x01/*HTCLIENT*/)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)12/*HTTOP*/ ;
                            else
                                m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10/*HTLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2/*HTCAPTION*/ ;
                            else
                                m.Result = (IntPtr)11/*HTRIGHT*/ ;
                        }
                        else
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)15/*HTBOTTOM*/ ;
                            else
                                m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
                        }
                    }
                    return;
            }
            base.WndProc(ref m);
        }
        protected override CreateParams CreateParams

        {
            get
            {
                const int WS_CAPTION = 0x00C00000;
                CreateParams baseParams = base.CreateParams;
                //Get rid of caption
                baseParams.Style = baseParams.Style & ~WS_CAPTION;
                return baseParams;
            }
        }
        private void btnClientesMenu_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
           
            Clientes clientes = new Clientes();
            clientes.Size = new Size(wa.Width -90, wa.Height - 60);
            pnlMain.Controls.Add(clientes);
            SelectedLineMenu("pnlLineClientes");


            this.LblTitle.Text = "CLIENTES";


        }
        private void btnCotizaMenu_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            Cotizaciones cotizaciones = new Cotizaciones();
            cotizaciones.Size = new Size(wa.Width - 90, wa.Height);
            pnlMain.Controls.Add(cotizaciones);
            SelectedLineMenu("pnlLineCotizaciones");


            pnlMain.Controls.Add(new Cotizaciones(""));
            SelectedLineMenu();
            pnlLineCotizaciones.Visible = true;
            this.LblTitle.Text = "COTIZACIONES";
        }
        private void btnPedidosMenu_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(new Pedidos("","",""));
            SelectedLineMenu();
            pnlLinePedidos.Visible = true;
            this.LblTitle.Text = "PEDIDOS";
        }
        private void btnProdMenu_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(new Productos());
            SelectedLineMenu("pnlLineProductos");


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
            SelectedLineMenu("pnlLineInventario");
            
            this.LblTitle.Text = "INVENTARIO";
        }

        private void btnFacturasMenu_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(new Facturacion());
            SelectedLineMenu("pnlLineFacturas");


            this.LblTitle.Text = "FACTURAS";
        }

        private void btnReportesMenu_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(new Reportes());
            SelectedLineMenu("pnlLineReportes");


            this.LblTitle.Text = "REPORTES";
        }
        private void btnCorteMenu_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(new Corte());
            SelectedLineMenu("pnlLineCorte");


            this.LblTitle.Text = "CORTES";
        }
        private void btnPLealMenu_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(new PLealtad());
            SelectedLineMenu("pnlLinePLealtad");
            this.LblTitle.Text = "PUNTOS LEALTAD";

        }
        private void btnConfigMenu_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(new Configuraciones());
            SelectedLineMenu("pnlLineConfiguracion");
            
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

        public void SelectedLineMenu(string idPanel)
        {
            pnlLineClientes.Visible         = pnlLineClientes.Name      == idPanel;
            pnlLineCotizaciones.Visible     = pnlLineCotizaciones.Name  == idPanel;
            pnlLinePedidos.Visible          = pnlLinePedidos.Name       == idPanel;
            pnlLineProductos.Visible        = pnlLineProductos.Name     == idPanel;
            pnlLineInventario.Visible       = pnlLineInventario.Name    == idPanel;
            pnlLineFacturas.Visible         = pnlLineFacturas.Name      == idPanel;
            pnlLineReportes.Visible         = pnlLineReportes.Name      == idPanel;
            pnlLineCorte.Visible            = pnlLineCorte.Name         == idPanel;
            pnlLinePLealtad.Visible         = pnlLinePLealtad.Name      == idPanel;
            pnlLineConfiguracion.Visible    = pnlLineConfiguracion.Name == idPanel;

            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Size = this.MinimumSize;
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
