using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRtail
{
    public class RespuestaAPI
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("idResponseSAP")]
        public string idResponseSAP { get; set; }

        [JsonProperty("DocEntry")]
        public string docEntryGenerado { get; set; }
    }
}
