using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DRtail
{
    delegate void Function();

    public partial class frmLogin : Form //, DPFP.Capture.EventHandler
    {
        //public int PROBABILITY_ONE = 0x7FFFFFFF;
        //bool registrationInProgress = false;
        //int fingerCount = 0;
        //System.Drawing.Graphics graphics;
        //System.Drawing.Font font;
        //DPFP.Capture.ReadersCollection readers;
        //DPFP.Capture.ReaderDescription readerDescription;
        //DPFP.Capture.Capture capturer;
        ////DPFP.Template template;
        //DPFP.FeatureSet[] regFeatures;
        //DPFP.FeatureSet verFeatures;
        //DPFP.Processing.Enrollment createRegTemplate;
        //DPFP.Verification.Verification verify;
        //DPFP.Capture.SampleConversion converter;
        //DatosUsuario dtos = new DatosUsuario();
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void pictBxHuella_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();
            menu.Show();

            this.Hide();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                txtUsaurio.Focus();
            }
            catch
            {
                MessageBox.Show("Error en Load");
            }
        }

        private void txtCodigoBarras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (InicioSesion() == true)
                {
                    frmMenu menu = new frmMenu();
                    this.Hide();
                    menu.Show();

                }
            }
        }

        public Boolean InicioSesion()
        {
            Boolean inicio = false;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.RutaApi + "login?usuario=" + txtUsaurio.Text + "&pass=" + txtPassword.Text);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    var j = JsonConvert.DeserializeObject<RespuestaAPI>(result);
                    //MessageBox.Show(j.Message);
                    if (j.Message == "El logueo fue correcto")
                        inicio = true;
                    lblError.Text = j.Message;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Iniciar Sesion:" + ex.Message + " " + Properties.Settings.Default.RutaApi);
            }
            return inicio;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pnlBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (InicioSesion() == true)
            //if (true)
            {
                //frmMenu menu = new frmMenu();
                frmMenuLateral menu = new frmMenuLateral();
                this.Hide();
                menu.Show();

            }

        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (InicioSesion() == true)
                {
                    //frmMenu menu = new frmMenu();
                    frmMenuLateral menu = new frmMenuLateral();
                    this.Hide();
                    menu.Show();

                }
            }
        }
    }
}
