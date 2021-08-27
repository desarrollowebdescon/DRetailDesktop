using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRtail
{
    public class DatosFactura

    {
        [JsonProperty("Numero de Entrega")]
        public int DocEntry { get; set; }

        [JsonProperty("Numero de Documento")]
        public string NoFactura { get; set; }

        [JsonProperty("Cliente")]
        public string Cliente { get; set; }

        [JsonProperty("Nombre")]
        public string Nombre { get; set; }

        [JsonProperty("FechaEntrega")]
        public DateTime FechaEntrega { get; set; }

        [JsonProperty("FechaDocumento")]
        public DateTime FechaDocumento { get; set; }

        [JsonProperty("Total")]
        public double TotalFacturado { get; set; }

        [JsonProperty("Descuento")]
        public double Descuento { get; set; }

        [JsonProperty("Estatus")]
        public string Estatus { get; set; } 
        
        [JsonProperty("Moneda")]
        public string Moneda { get; set; }
       
    }

}
