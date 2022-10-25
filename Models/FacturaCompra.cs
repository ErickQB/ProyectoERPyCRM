using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class FacturaCompra
    {
        public FacturaCompra()
        {
            Devolucion = new HashSet<Devolucion>();
            FacturaDetalleCompra = new HashSet<FacturaDetalleCompra>();
            PagoCompra = new HashSet<PagoCompra>();
        }

        public int IdFacturaCompra { get; set; }
        public string Serie { get; set; }
        public int NoFactura { get; set; }
        public int IdCotizacionCompra { get; set; }
        public float? SubTotal { get; set; }
        public float? Descuento { get; set; }
        public float? Total { get; set; }
        public int? IdDevolucion { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual CotizacionCompra IdCotizacionCompraNavigation { get; set; }
        public virtual ICollection<Devolucion> Devolucion { get; set; }
        public virtual ICollection<FacturaDetalleCompra> FacturaDetalleCompra { get; set; }
        public virtual ICollection<PagoCompra> PagoCompra { get; set; }
    }
}
