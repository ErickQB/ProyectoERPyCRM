using System;
using System.Collections.Generic;
using System.ComponentModel;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class Cobro
    {
        public int IdCobro { get; set; }
        [DisplayName("Factura")]
        public int IdFactura { get; set; }
        public DateTime Fecha { get; set; }
        [DisplayName("Tipo Pago")]
        public int IdTipoPago { get; set; }
        public string Correlativo { get; set; }
        public string Estado { get; set; }
        [DisplayName("Fech. Creado")]
        public DateTime? FechaCreacion { get; set; }
        [DisplayName("Fech. Actualizado")]
        public DateTime? FechaActualizacion { get; set; }

        [DisplayName("Factura")]
        public virtual FacturaVenta IdFacturaNavigation { get; set; }
        [DisplayName("Tipo Pago")]
        public virtual TipoPago IdTipoPagoNavigation { get; set; }
    }
}
