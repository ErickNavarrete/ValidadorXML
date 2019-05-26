using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ValidadorXML.Models
{
    public class Comprobante
    {
        public DateTime Fecha { get; set; }
        public string Serie{ get; set; }
        public string Folio { get; set; }
        public string FormaPago { get; set; }
        public string Version { get; set; }
        public decimal SubTotal { get; set; }
        public string Moneda { get; set; }
        public decimal Total { get; set; }
        public string TipoComprobante { get; set; }
        public string MetodoPago { get; set; }
        public Emisor Emisor { get; set; }
        public Receptor Receptor { get; set; }
    }
}