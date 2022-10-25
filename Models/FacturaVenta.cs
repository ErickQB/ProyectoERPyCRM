using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class FacturaVenta
    {
        public FacturaVenta()
        {
            Cobro = new HashSet<Cobro>();
            Despacho = new HashSet<Despacho>();
            FacturaDetalleVenta = new HashSet<FacturaDetalleVenta>();
        }

        public int IdFacturaVenta { get; set; }
        public int IdCotizacionVenta { get; set; }
        public int IdVendedor { get; set; }
        public DateTime Fecha { get; set; }
        public int IdCliente { get; set; }
        public string DireccionFactura { get; set; }
        public string DireccionEntrega { get; set; }
        public string Correlativo { get; set; }
        public string NitCliente { get; set; }
        public float? Iva { get; set; }
        public float? SubTotal { get; set; }
        public float? Descuento { get; set; }
        public float? Total { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual CotizacionVenta IdCotizacionVentaNavigation { get; set; }
        public virtual Vendedor IdVendedorNavigation { get; set; }
        public virtual ICollection<Cobro> Cobro { get; set; }
        public virtual ICollection<Despacho> Despacho { get; set; }
        public virtual ICollection<FacturaDetalleVenta> FacturaDetalleVenta { get; set; }
    }
}
