using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DRtail
{
    public class DatosSocios
    {
        [JsonProperty("Codigo")]
        public string CodigoCliente { get; set; }

        [JsonProperty("Nombre")]
        public string NombreCliente { get; set; }

        [JsonProperty("RFC")]
        public string RFC { get; set; }

        [JsonProperty("Telefono")]
        public string Telefono { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }
    }
}
