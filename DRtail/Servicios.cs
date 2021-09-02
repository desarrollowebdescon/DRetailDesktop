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

    }
}
