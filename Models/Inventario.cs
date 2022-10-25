using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class Inventario
    {
        public Inventario()
        {
            InventarioBodegaProducto = new HashSet<InventarioBodegaProducto>();
        }

        public int IdInventario { get; set; }
        public DateTime FechaConteo { get; set; }
        public TimeSpan? HoraConteo { get; set; }
        public int IdEmpleadoEncargado { get; set; }
        public string Observaciones { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual Empleado IdEmpleadoEncargadoNavigation { get; set; }
        public virtual ICollection<InventarioBodegaProducto> InventarioBodegaProducto { get; set; }
    }
}
