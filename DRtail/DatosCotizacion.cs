using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRtail
{
    public class DatosCotizacion
    {
        [JsonProperty("Numero de Documento")]
        public string NoCotizacion { get; set; }

        [JsonProperty("Numero de Entrega")]
        public string docentryCotizacion { get; set; }

        [JsonProperty("Cliente")]
        public string Cliente { get; set; }

        [JsonProperty("Nombre")]
        public string Nombre { get; set; }

        [JsonProperty("FechaEntrega")]
        public DateTime FechaEntrega { get; set; }

        [JsonProperty("FechaContabilizacion")]
        public DateTime FechaContabilizacion { get; set; }

        [JsonProperty("FechaDocumento")]
        public DateTime FechaDocumento { get; set; }

        [JsonProperty("FechaVencimiento")]
        public DateTime FechaVencimiento { get; set; }

        [JsonProperty("Moneda")]
        public string Moneda { get; set; }

        [JsonProperty("Estatus")]
        public string Estatus { get; set; }

        [JsonProperty("Descuento")]
        public string Descuento { get; set; }

        [JsonProperty("Total")]
        public string Total { get; set; }

        [JsonProperty("Comentarios")]
        public string Comentarios { get; set; }

        [JsonProperty("lineas")]
        public List<ArticulosCotizacion> articulosCotizaciones = new List<ArticulosCotizacion>();

    }

    public class ArticulosCotizacion
    {
        [JsonProperty("Articulo")]
        public string Articulo { get; set; }

        [JsonProperty("Cantidad")]
        public double Cantidad { get; set; }
    }

    public class DatosPedido
    {
        [JsonProperty("docentry")]
        public string NoCotizacionRelacionada { get; set; }

        [JsonProperty("Numero de Documento")]
        public string noPedido { get; set; }

        [JsonProperty("Numero de Entrega")]
        public string docEntryPedido { get; set; }

        [JsonProperty("Cliente")]
        public string Cliente { get; set; }

        [JsonProperty("Nombre")]
        public string Nombre { get; set; }

        [JsonProperty("FechaEntrega")]
        public DateTime FechaEntrega { get; set; }

        [JsonProperty("FechaContabilizacion")]
        public DateTime FechaContabilizacion { get; set; }

        [JsonProperty("FechaDocumento")]
        public DateTime FechaDocumento { get; set; }

        [JsonProperty("FechaVencimiento")]
        public DateTime FechaVencimiento { get; set; }

        [JsonProperty("Moneda")]
        public string Moneda { get; set; }

        [JsonProperty("Estatus")]
        public string Estatus { get; set; }

        [JsonProperty("Descuento")]
        public string Descuento { get; set; }

        [JsonProperty("Total")]
        public string Total { get; set; }

        [JsonProperty("Comentarios")]
        public string Comentarios { get; set; }

        [JsonProperty("lineas")]
        public List<ArticulosPedido> articulosPedidos = new List<ArticulosPedido>();

    }

    public class ArticulosPedido
    {
        [JsonProperty("Articulo")]
        public string Articulo { get; set; }

        [JsonProperty("Cantidad")]
        public double Cantidad { get; set; }
    }

    public class DocEntryDocumento
    {
        [JsonProperty("docEntry")]
        public string docEntry { get; set; }

    }

    public class Cotización
    {
        [JsonProperty("Encabezado")]
        public List<Encabezado> encabezado = new List<Encabezado>();// { get; set; }

        [JsonProperty("Lineas")]
        public List<Lineas> lineas = new List<Lineas>();// { get; set; }
    }

    public class Encabezado
    {
        [JsonProperty("Cliente")]
        public string Cliente { get; set; }

        [JsonProperty("Nombre")]
        public string Nombre { get; set; }

        [JsonProperty("Total")]
        public string Total { get; set; }
    }

    public class Lineas
    {
        [JsonProperty("Articulo")]
        public string Articulo { get; set; }

        [JsonProperty("Cantidad")]
        public double Cantidad { get; set; }

        [JsonProperty("Precio Unitario")]
        public string PrecioU { get; set; }

        [JsonProperty("Total")]
        public string Total { get; set; }

        [JsonProperty("Descuento")]
        public string Descuento { get; set; }

        [JsonProperty("Moneda")]
        public string Moneda { get; set; }
    }
}
