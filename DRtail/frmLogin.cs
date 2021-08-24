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

            //try
            //{
            //    graphics = this.CreateGraphics();
            //    font = new Font("Times New Roman", 12, FontStyle.Bold, GraphicsUnit.Pixel);
            //    DPFP.Capture.ReadersCollection coll = new DPFP.Capture.ReadersCollection();

            //    regFeatures = new DPFP.FeatureSet[4];
            //    for (int i = 0; i < 4; i++)
            //        regFeatures[i] = new DPFP.FeatureSet();

            //    verFeatures = new DPFP.FeatureSet();
            //    createRegTemplate = new DPFP.Processing.Enrollment();

            //    readers = new DPFP.Capture.ReadersCollection();

            //    for (int i = 0; i <= 4; i++)
            //    {
            //        try
            //        {
            //            readerDescription = readers[i];
            //            if ((readerDescription.Vendor == "Digital Persona, Inc.") || (readerDescription.Vendor == "DigitalPersona, Inc."))
            //            {
            //                try
            //                {
            //                    capturer = new DPFP.Capture.Capture(readerDescription.SerialNumber, DPFP.Capture.Priority.Normal);//CREAMOS UNA OPERACION DE CAPTURAS.
            //                }
            //                catch (Exception ex)
            //                {
            //                    MessageBox.Show("Error frmPrueba()" + ex.Message);
            //                }
            //                capturer.EventHandler = this;
            //                //AQUI CAPTURAMOS LOS EVENTOS.

            //                converter = new DPFP.Capture.SampleConversion();
            //                try
            //                {
            //                    verify = new DPFP.Verification.Verification();
            //                }
            //                catch (Exception ex)
            //                {
            //                    MessageBox.Show("Ex: " + ex.ToString());
            //                }
            //                break;
            //            }
            //        }
            //        catch
            //        {
            //            MessageBox.Show("LECTOR DESCONECTADO");
            //        }

            //    }
            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show("Lector Desconectado!");
            //}


        }

        private void pictBxHuella_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();
            menu.Show();

            this.Hide();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

            //List<DatosUsuario> lstDU = ConsultasBD.LlenarCombo("select idUsuario, usuario from usuarios order by usuario");
           
            //cmbxUsuarios.DisplayMember = "display";
            //cmbxUsuarios.ValueMember = "value";
            //cmbxUsuarios.ResetText();

            try
            {
                //if (createRegTemplate == null)
                //{
                //    MessageBox.Show("Lector Desconectado!!!");
                //}

                //else
                //{


                //    registrationInProgress = true;
                //    fingerCount = 0;
                //    createRegTemplate.Clear();
                //    if (capturer != null)
                //    {
                //        try
                //        {
                //            capturer.StartCapture();
                //        }
                //        catch (Exception ex)
                //        {
                //            MessageBox.Show("Error en Load" + ex.Message);
                //        }
                //    }
                //}
            }
            catch
            {
                MessageBox.Show("Error en Load");
            }
        }

        //public void OnComplete(object obj, string info, DPFP.Sample sample)
        //{
        //    this.Invoke(new Function(delegate ()
        //    {
        //        Bitmap tempRef = null;
        //        converter.ConvertToPicture(sample, ref tempRef);
        //        System.Drawing.Image img = tempRef;
        //        //AQUI MOSTRAMOS LA HUELLA CAPTURADA EN EL PICTUREBOX Y LA REDIMENSIONAMOS AL TAMAÑO DEL PICTUREBOX
        //        Bitmap bmp = new Bitmap(converter.ConvertToPicture(sample, ref tempRef), pctBxHuella.Size);
        //        String pxFormat = bmp.PixelFormat.ToString();
        //        Point txtLoc = new Point(pctBxHuella.Width / 2 - 20, 0);
        //        graphics = Graphics.FromImage(bmp);
        //        //AHORA CUANDO EL LECTOR YA TENGA CAPTURADA UNA HUELLA COMIENZA TODO EL PROCESO
        //        if (registrationInProgress)
        //        {
        //            try
        //            {
        //                //CAPTURAMOS LA HUELLA                        
        //                regFeatures[fingerCount] = ExtractFeatures(sample, DPFP.Processing.DataPurpose.Enrollment);
        //                if (regFeatures[fingerCount] != null)
        //                {
        //                    string b64 = Convert.ToBase64String(regFeatures[fingerCount].Bytes);
        //                    regFeatures[fingerCount].DeSerialize(Convert.FromBase64String(b64));

        //                    if (regFeatures[fingerCount] == null)
        //                    {
        //                        txtLoc.X = pctBxHuella.Width / 2 - 26;
        //                        graphics.DrawString("Bad Press", font, Brushes.Cyan, txtLoc);
        //                        return;
        //                    }
        //                    ++fingerCount;

        //                    //createRegTemplate.AddFeatures(regFeatures[fingerCount - 1]);
        //                    graphics = Graphics.FromImage(bmp);
        //                    if (fingerCount < 1)
        //                    {
        //                        graphics.DrawString("" + fingerCount + " De 1", font, Brushes.Black, txtLoc);
        //                    }
        //                    if (createRegTemplate.TemplateStatus == DPFP.Processing.Enrollment.Status.Failed)
        //                    {
        //                        capturer.StopCapture();
        //                        fingerCount = 0;
        //                        MessageBox.Show("Error de captura");
        //                        fingerCount = 0;
        //                        capturer.StartCapture();
        //                    }
        //                    else
        //                    {
        //                        if (fingerCount == 1) //CAPTURAMOS UNA VEZ LA HUELLA PAR COMPARARLA
        //                        {
        //                            pctBxHuella.Image = bmp;
        //                            verFeatures = ExtractFeatures(sample, DPFP.Processing.DataPurpose.Verification);
        //                            bool mensaje = comparar(ExtractFeatures(sample, DPFP.Processing.DataPurpose.Verification)); //METODO PARA COMPARAR LA HUELLA EN LA BD
        //                            if (mensaje == true) //SI EL USUARIO ESTA REGISTRADO:
        //                            {
        //                                frmMenu menu = new frmMenu();
        //                                menu.dtosUsuarios = dtos;
        //                                menu.Show();

        //                                this.Hide();
        //                            }
        //                            else //SI NO ESTA REGISTRADO
        //                            {
        //                                MessageBox.Show("Usuario no registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            catch (DPFP.Error.SDKException ex)
        //            {
        //                capturer.StopCapture();
        //                MessageBox.Show("Error en SDK: " + ex.Message);
        //                fingerCount = 0;
        //                capturer.StartCapture();
        //            }
        //        }
        //    }));
        //}

        //protected DPFP.FeatureSet ExtractFeatures(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
        //{
        //    DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction();

        //    DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
        //    DPFP.FeatureSet features = new DPFP.FeatureSet();
        //    try
        //    {
        //        Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al extraer" + ex.Message);
        //    }
        //    if (feedback == DPFP.Capture.CaptureFeedback.Good)
        //        return features;
        //    else
        //        return null;
        //}

        //private bool comparar(DPFP.FeatureSet featset)
        //{
        //    bool mensaje = false;
        //    try
        //    {
        //        DataTable dtDatos = ConsultasBD.EjecutaQueryDT("select * from usuarios where usuario = '" + cmbxUsuarios.Text + "'");

        //        if (dtDatos.Rows.Count > 0)
        //        {
        //            dtos.idUsuario = int.Parse(dtDatos.Rows[0]["idUsuario"].ToString());
        //            dtos.idPerfil = int.Parse(dtDatos.Rows[0]["idPerfil"].ToString());
        //            dtos.usuario = dtDatos.Rows[0]["usuario"].ToString();
        //            dtos.nombreC = dtDatos.Rows[0]["nombreC"].ToString();
        //            dtos.huella = dtDatos.Rows[0]["huella"].ToString();

        //            DPFP.Verification.Verification ver = new DPFP.Verification.Verification();
        //            DPFP.Verification.Verification.Result resulta = new DPFP.Verification.Verification.Result();

        //            byte[] b = new byte[1632];
        //            b = Convert.FromBase64String(dtos.huella); //pasamos el string de base-64 a un arreglo byte. //creamos una varibale de tipo Template donde guardaremos el template 
        //            DPFP.Template templates = new DPFP.Template();//lo des serializamos para poder compararlo
        //            templates.DeSerialize(b);
        //            ver.Verify(featset, templates, ref resulta); //COMPARAMOS LA HUELLA CAPTURADA CON LAS QUE ESTAN EN LA BD

        //            if (resulta.Verified == true) //SI EXISTE EN LA BD
        //            {
        //                mensaje = true;
        //            }
        //        }


        //    }
        //    catch (Exception er)
        //    {
        //        MessageBox.Show("Error al querer comparar: " + er + "...");
        //    }
        //    return mensaje;
        //}

        //public void OnFingerGone(object Capture, string ReaderSerialNumber)
        //{
        //    this.Invoke(new Function(delegate ()
        //    {
        //        //textBox1.Text = "captura";
        //    }));
        //}

        ////EVENTO QUE MUESTRA EL MENSAJE LECTOR TOCADO
        //public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        //{

        //    this.Invoke(new Function(delegate ()
        //    {
        //        //textBox1.Text = "Lector tocado";
        //    }));
        //}

        ////EVENTO QUE MUESTRA EL MENSAJE LECTOR CONECTADO
        //public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        //{
        //    this.Invoke(new Function(delegate ()
        //    {
        //        Console.WriteLine("Lector Conectado");
        //        //MessageBox.Show("Lector Conectado");
        //    }));
        //}

        ////EVENTO QUE MUESTRA EL MENSAJE LECTOR DESCONECTADO
        //public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        //{

        //    this.Invoke(new Function(delegate ()
        //    {
        //        //textBox1.Text = "Lector Desconectado";
        //        MessageBox.Show("Lector Desconectado");
        //    }));

        //}

        //public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback)
        //{
        //    MessageBox.Show("Sample quality!!!! " + CaptureFeedback.ToString());
        //}

        string resp = "";

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
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://54.39.26.9:62436/api/login?usuario="+ txtUsaurio.Text  + "&pass=" + txtPassword.Text);
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
                MessageBox.Show("Error al Iniciar Sesion:" + ex.Message);
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
    }
}
