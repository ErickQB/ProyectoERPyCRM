using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class Devolucion
    {
        public Devolucion()
        {
            DevolucionManual = new HashSet<DevolucionManual>();
        }

        public int IdDevolucion { get; set; }
        public int IdFacturaCompra { get; set; }
        public int IdProducto { get; set; }
        public float Cantidad { get; set; }
        public string Descripcion { get; set; }
        public string Motivo { get; set; }
        public string DescargarInventario { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual FacturaCompra IdFacturaCompraNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
        public virtual ICollection<DevolucionManual> DevolucionManual { get; set; }
    }
}
