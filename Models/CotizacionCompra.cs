using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class CotizacionCompra
    {
        public CotizacionCompra()
        {
            CotizacionDetalleCompra = new HashSet<CotizacionDetalleCompra>();
            FacturaCompra = new HashSet<FacturaCompra>();
        }

        public int IdCotizacionCompra { get; set; }
        public DateTime FechaCotizacion { get; set; }
        public int IdProveedor { get; set; }
        public float? SubTotal { get; set; }
        public float? Descuento { get; set; }
        public float? Total { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual Proveedor IdProveedorNavigation { get; set; }
        public virtual ICollection<CotizacionDetalleCompra> CotizacionDetalleCompra { get; set; }
        public virtual ICollection<FacturaCompra> FacturaCompra { get; set; }
    }
}
