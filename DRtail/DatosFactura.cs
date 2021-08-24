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
        [JsonProperty("NoPedido")]
        public int NoPedido { get; set; }

        [JsonProperty("NoFactura")]
        public string NoFactura { get; set; }
        
        [JsonProperty("TotalFacturado")]
        public double TotalFacturado { get; set; }
        
        [JsonProperty("StatusPago")]
        public string StatusPago { get; set; } 
        
        [JsonProperty("CódigoCliente")]
        public string CodigoCliente { get; set; }
       
    }

}
