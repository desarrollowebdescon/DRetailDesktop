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
        [JsonProperty("docentry")]
        public string NoPedidoRelacionada { get; set; }

        [JsonProperty("Numero de Entrega")]
        public int DocEntryFact { get; set; }

        [JsonProperty("Numero de Documento")]
        public string NoFactura { get; set; }

        [JsonProperty("Cliente")]
        public string Cliente { get; set; }

        [JsonProperty("Nombre")]
        public string Nombre { get; set; }

        [JsonProperty("FechaContabilizacion")]
        public DateTime FechaContabilizacion { get; set; }

        [JsonProperty("FechaVencimiento")]
        public DateTime FechaVencimiento { get; set; }

        [JsonProperty("Total")]
        public double TotalFacturado { get; set; }

        [JsonProperty("Descuento")]
        public double Descuento { get; set; }

        [JsonProperty("Estatus")]
        public string Estatus { get; set; }

        [JsonProperty("Moneda")]
        public string Moneda { get; set; }

        [JsonProperty("Comentarios")]
        public string Comentarios { get; set; }

        [JsonProperty("tipo")]
        public string tipo { get; set; }

        [JsonProperty("lineas")]
        public List<ArticulosFactura> articulosFacturas = new List<ArticulosFactura>();

        [JsonProperty("DatosFiscales")]
        public DatosFiscalesFactura DatosFiscales = new DatosFiscalesFactura();

    }

    public class ArticulosFactura
    {
        [JsonProperty("Articulo")]
        public string Articulo { get; set; }

        [JsonProperty("Cantidad")]
        public string Cantidad { get; set; }

        [JsonProperty("Precio")]
        public double Precio { get; set; }
    }

    public class DatosFiscalesFactura
    {
        [JsonProperty("certificado")]
        public string certificado { get; set; }

        [JsonProperty("formaPago")]
        public string formaPago { get; set; }

        [JsonProperty("metodopago")]
        public string metodopago { get; set; }

        [JsonProperty("usocfdi")]
        public string usocfdi { get; set; }
    }

}
