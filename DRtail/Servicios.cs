using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DRtail
{
    class Servicios
    {
        #region "Variables"

        public static frmMenuLateral menuLateral;

        #endregion


        public static List<DatosCotizacion> getCotizaciones()
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://54.39.26.9:62436/api/consultarAllCotizaciones");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    var j = JsonConvert.DeserializeObject<List<DatosCotizacion>>(result);

                    return j;

                }
            }
            catch (Exception ex)
            {
                return new List<DatosCotizacion>();
            }
        }

        public static List<DatosPedido> getPedidos()
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://54.39.26.9:62436/api/consultarAllPedidos");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    var j = JsonConvert.DeserializeObject<List<DatosPedido>>(result);

                    return j;

                }
            }
            catch (Exception ex)
            {
                return new List<DatosPedido>();
            }
        }

        public static List<DatosFactura> getFacturas()
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://54.39.26.9:62436/api/consultarAllFacturas");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    var j = JsonConvert.DeserializeObject<List<DatosFactura>>(result);

                    return j;

                }
            }
            catch (Exception ex)
            {
                return new List<DatosFactura>();
            }
        }

        public static List<DatosArticulos> GetArticulos()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://54.39.26.9:62436/api/consultarAllArticulosEsc");
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<DatosArticulos>>(json);
                }
            }
            catch (Exception ex)
            {

                return new List<DatosArticulos>();
            }

        }
        public static List<DatosSocios> getSocios()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://54.39.26.9:62436/api/consultarAllSociosEsc");
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<DatosSocios>>(json);
                }
            }
            catch (Exception ex)
            {
                return new List<DatosSocios>();
            }
        }

        public static Cotización getCotizacionOrigen(string cotOrigen)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://54.39.26.9:62436/api/consultarCotizacion?docNum=" + cotOrigen);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<Cotización> (json);
                }
            }
            catch (Exception ex)
            {
                return new Cotización();
            }
        }


        public static Boolean enviarCorreo(string U_Correo, string U_Path, string tipoDocumento)
        {
            bool enviado = false;

            try
            {
                string SMTP = "smtp.gmail.com"; // lc_ServidorSMTP
                string Usuario = "testdesarrollosdescon@gmail.com"; // lc_UsuarioCorreo
                string Contraseña = "Descon2020"; // lc_ContraseñaCorreo
                int Puerto = System.Convert.ToInt32(587);
                System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();
                correo.From = new System.Net.Mail.MailAddress(Usuario);
                correo.Subject = "Envio de " + tipoDocumento + " de Etrusca";
                correo.Body = "Buen dìa enviamos el siguiente correo como prueba de funcionalidad del mismo, quedando atentos a sus comentarios y agradeciendo su atención";
                correo.To.Add(U_Correo);
                System.Net.Mail.SmtpClient Servidor = new System.Net.Mail.SmtpClient();
                Servidor.Host = SMTP;
                Servidor.Port = Puerto;
                //System.Net.Mail.Attachment archivo = new System.Net.Mail.Attachment(U_Path);
                //correo.Attachments.Add(archivo);
                if (1 == 1)
                    Servidor.EnableSsl = true;
                else
                    Servidor.EnableSsl = false;
                Servidor.Credentials = new System.Net.NetworkCredential(Usuario, Contraseña);
                Servidor.Send(correo);
                correo.Attachments.Dispose();
                enviado = true;
            }
            catch (Exception ex)
            {
                enviado = false;
            }
            return enviado;
        }

    }
}
