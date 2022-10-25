using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class SueldoEmpleado
    {
        public SueldoEmpleado()
        {
            PagoPlanilla = new HashSet<PagoPlanilla>();
        }

        public int IdSueldoEmpleado { get; set; }
        public DateTime Mes { get; set; }
        public DateTime Anio { get; set; }
        public int IdEmpleado { get; set; }
        public float? Descuento { get; set; }
        public float TotalPago { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual Empleado IdEmpleadoNavigation { get; set; }
        public virtual ICollection<PagoPlanilla> PagoPlanilla { get; set; }
    }
}
