using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class FacturaDetalleVenta
    {
        public int IdFacturaDetalleVenta { get; set; }
        public int IdFacturaVenta { get; set; }
        public float? Cantidad { get; set; }
        public int IdProducto { get; set; }
        public float PrecioUnitario { get; set; }
        public float SubTotal { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string Estado { get; set; }

        public virtual FacturaVenta IdFacturaVentaNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
