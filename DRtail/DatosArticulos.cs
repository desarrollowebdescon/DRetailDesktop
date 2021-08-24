using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DRtail
{
    public class DatosArticulos
    {
        [JsonProperty("Codigo")]
        public string Codigo { get; set; }

        [JsonProperty("Nombre")]
        public string Descripcion { get; set; }

        [JsonProperty("Costo de Articulo")]
        public double Costo { get; set; }
        [JsonProperty("Impuesto")]
        public double Impuesto { get; set; }
        [JsonProperty("Lote")]
        public double Lote { get; set; }
        [JsonProperty("Serie")]
        public double Serie { get; set; }
        [JsonProperty("Total stock")]
        public double TotalStock { get; set; }
    }
}

