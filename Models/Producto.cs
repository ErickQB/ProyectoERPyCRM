using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class Producto
    {
        public Producto()
        {
            BodegaProducto = new HashSet<BodegaProducto>();
            CotizacionDetalleCompra = new HashSet<CotizacionDetalleCompra>();
            CotizacionDetalleVenta = new HashSet<CotizacionDetalleVenta>();
            Devolucion = new HashSet<Devolucion>();
            DevolucionManual = new HashSet<DevolucionManual>();
            FacturaDetalleCompra = new HashSet<FacturaDetalleCompra>();
            FacturaDetalleVenta = new HashSet<FacturaDetalleVenta>();
            InventarioIngresoManual = new HashSet<InventarioIngresoManual>();
            Oferta = new HashSet<Oferta>();
        }

        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public float Cantidad { get; set; }
        public float PrecioCompra { get; set; }
        public float PrecioVentaPublicoGeneral { get; set; }
        public int? IdTipoClienteA { get; set; }
        public float? PrecioClienteA { get; set; }
        public int? IdTipoClienteB { get; set; }
        public float? PrecioClienteB { get; set; }
        public int? IdTipoClienteC { get; set; }
        public float? PrecioClienteC { get; set; }
        public int? IdTipoClienteD { get; set; }
        public float? PrecioClienteD { get; set; }
        public int? IdTipoClienteE { get; set; }
        public float? PrecioClienteE { get; set; }
        public int IdProveedor { get; set; }
        public string FotoProducto { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual Proveedor IdProveedorNavigation { get; set; }
        public virtual TipoCliente IdTipoClienteANavigation { get; set; }
        public virtual TipoCliente IdTipoClienteBNavigation { get; set; }
        public virtual TipoCliente IdTipoClienteCNavigation { get; set; }
        public virtual TipoCliente IdTipoClienteDNavigation { get; set; }
        public virtual TipoCliente IdTipoClienteENavigation { get; set; }
        public virtual ICollection<BodegaProducto> BodegaProducto { get; set; }
        public virtual ICollection<CotizacionDetalleCompra> CotizacionDetalleCompra { get; set; }
        public virtual ICollection<CotizacionDetalleVenta> CotizacionDetalleVenta { get; set; }
        public virtual ICollection<Devolucion> Devolucion { get; set; }
        public virtual ICollection<DevolucionManual> DevolucionManual { get; set; }
        public virtual ICollection<FacturaDetalleCompra> FacturaDetalleCompra { get; set; }
        public virtual ICollection<FacturaDetalleVenta> FacturaDetalleVenta { get; set; }
        public virtual ICollection<InventarioIngresoManual> InventarioIngresoManual { get; set; }
        public virtual ICollection<Oferta> Oferta { get; set; }
    }
}
