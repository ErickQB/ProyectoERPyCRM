using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class CotizacionDetalleVenta
    {
        public int IdCotizacionDetalleVenta { get; set; }
        public int IdCotizacionVenta { get; set; }
        public float Cantidad { get; set; }
        public int IdProducto { get; set; }
        public float PrecioUnitario { get; set; }
        public float SubTotal { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string Estado { get; set; }

        public virtual CotizacionVenta IdCotizacionVentaNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
