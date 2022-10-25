using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class InventarioIngresoManual
    {
        public int IdInventarioIngresoManual { get; set; }
        public int IdProducto { get; set; }
        public float Cantidad { get; set; }
        public string MotivoCarga { get; set; }
        public string Estado { get; set; }
        public int IdEmpleadoAutorizado { get; set; }
        public DateTime FechaIngreso { get; set; }
        public TimeSpan HoraIngreso { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual Empleado IdEmpleadoAutorizadoNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
