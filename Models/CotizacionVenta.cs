using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class CotizacionVenta
    {
        public CotizacionVenta()
        {
            CotizacionDetalleVenta = new HashSet<CotizacionDetalleVenta>();
            FacturaVenta = new HashSet<FacturaVenta>();
        }

        public int IdCotizacionVenta { get; set; }
        public DateTime Fecha { get; set; }
        public string EstadoCotizacion { get; set; }
        public int IdVendedor { get; set; }
        public int IdCliente { get; set; }
        public float? SubTotal { get; set; }
        public float? Descuento { get; set; }
        public float? Total { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Vendedor IdVendedorNavigation { get; set; }
        public virtual ICollection<CotizacionDetalleVenta> CotizacionDetalleVenta { get; set; }
        public virtual ICollection<FacturaVenta> FacturaVenta { get; set; }
    }
}
