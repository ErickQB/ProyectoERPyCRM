using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class TipoConsumo
    {
        public TipoConsumo()
        {
            CotizacionDetalleCompra = new HashSet<CotizacionDetalleCompra>();
            FacturaDetalleCompra = new HashSet<FacturaDetalleCompra>();
        }

        public int IdTipoConsumo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual ICollection<CotizacionDetalleCompra> CotizacionDetalleCompra { get; set; }
        public virtual ICollection<FacturaDetalleCompra> FacturaDetalleCompra { get; set; }
    }
}
