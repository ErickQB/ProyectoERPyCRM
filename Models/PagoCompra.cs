using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class PagoCompra
    {
        public int IdPagoCompra { get; set; }
        public DateTime FechaPago { get; set; }
        public int IdFacturaCompra { get; set; }
        public float Total { get; set; }
        public string Estado { get; set; }
        public int IdTipoPago { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual FacturaCompra IdFacturaCompraNavigation { get; set; }
        public virtual TipoPago IdTipoPagoNavigation { get; set; }
    }
}
