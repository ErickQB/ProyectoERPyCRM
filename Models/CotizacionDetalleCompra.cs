using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class CotizacionDetalleCompra
    {
        public int IdCotizacionDetalleCompra { get; set; }
        public int IdCotizacionCompra { get; set; }
        public float Cantidad { get; set; }
        public int IdTipoConsumo { get; set; }
        public int? IdProducto { get; set; }
        public string Descripcion { get; set; }
        public float SubTotal { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual CotizacionCompra IdCotizacionCompraNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
        public virtual TipoConsumo IdTipoConsumoNavigation { get; set; }
    }
}
