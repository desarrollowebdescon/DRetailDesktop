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
        public static List<DatosFactura> getFacturas()
        {
            List<DatosFactura> facturas = new List<DatosFactura>();
            DatosFactura df1 = new DatosFactura();
            df1.CodigoCliente = "E-00005";
            df1.NoFactura = "25001";
            df1.NoPedido = 25000;
            df1.TotalFacturado = 2500.00;
            df1.StatusPago = "Pagado";
            DatosFactura df2 = new DatosFactura();
            df2.CodigoCliente = "E-00005";
            df2.NoFactura = "25001";
            df2.NoPedido = 25000;
            df2.TotalFacturado = 2500.00;
            df2.StatusPago = "Pagado";
            DatosFactura df3 = new DatosFactura();
            df3.CodigoCliente = "E-00006";
            df3.NoFactura = "25002";
            df3.NoPedido = 25005;
            df3.TotalFacturado = 2500.00;
            df3.StatusPago = "Pagado";
            DatosFactura df4 = new DatosFactura();
            df4.CodigoCliente = "E-00007";
            df4.NoFactura = "25005";
            df4.NoPedido = 25010;
            df4.TotalFacturado = 2500.00;
            df4.StatusPago = "Pagado";


            facturas.Add(df1);
            facturas.Add(df1);
            facturas.Add(df1);
            facturas.Add(df2);
            facturas.Add(df3);
            facturas.Add(df4);
            facturas.Add(df4);


            return facturas;

        }

    }
}
