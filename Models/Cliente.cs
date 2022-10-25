using System;
using System.Collections.Generic;
using System.ComponentModel;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            CotizacionVenta = new HashSet<CotizacionVenta>();
            FacturaVenta = new HashSet<FacturaVenta>();
        }

        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [DisplayName("Dire. Entrega")]
        public string DireccionEntrega { get; set; }
        [DisplayName("Dire. Factura")]
        public string DireccionFactura { get; set; }
        [DisplayName("NIT")]
        public string Nit { get; set; }
        [DisplayName("Tipo Cliente")]
        public int? IdTipoCliente { get; set; }
        public string Estado { get; set; }
        [DisplayName("Fech. Creado")]
        public DateTime? FechaCreacion { get; set; }
        [DisplayName("Fech. Actualizado")]
        public DateTime? FechaActualizacion { get; set; }
        [DisplayName("Tipo Cliente")]
        public virtual TipoCliente IdTipoClienteNavigation { get; set; }
        [DisplayName("Cotz. Venta")]
        public virtual ICollection<CotizacionVenta> CotizacionVenta { get; set; }
        [DisplayName("Fac. Venta")]
        public virtual ICollection<FacturaVenta> FacturaVenta { get; set; }
    }
}
