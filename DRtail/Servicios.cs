﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.RutaApi + "consultarAllCotizaciones?DOCNUM=&CARDCODE=&FECHAINICIO=&FECHAFIN=");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    var y = (JObject)JsonConvert.DeserializeObject(result);
                    var j = JsonConvert.DeserializeObject<List<DatosCotizacion>>(y.SelectToken("documentos").ToString());

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
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.RutaApi + "consultarAllPedidos?NOPEDIDO=&CARDCODE=&CARDNAME=&ESTATUS=");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using ( var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    var y = (JObject)JsonConvert.DeserializeObject(result);
                    var j = JsonConvert.DeserializeObject<List<DatosPedido>>(y.SelectToken("documentos").ToString());
                    

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
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.RutaApi + "consultarAllFacturas");
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
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.RutaApi + "consultarAllArticulosEsc");
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
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.RutaApi + "consultarAllSociosEsc");
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
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.RutaApi + "consultarCotizacion?docNum=" + cotOrigen);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<Cotización>(json);
                }
            }
            catch (Exception ex)
            {
                return new Cotización();
            }
        }


    }
}
