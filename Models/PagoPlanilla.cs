using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class PagoPlanilla
    {
        public int IdPago { get; set; }
        public DateTime FechaPago { get; set; }
        public string TipoPagoPlanilla { get; set; }
        public int? IdSueldoEmpleado { get; set; }
        public float? TotalSueldoEmpleado { get; set; }
        public int? IdSueldoVendedor { get; set; }
        public float? TotalSueldoVendedor { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual SueldoEmpleado IdSueldoEmpleadoNavigation { get; set; }
        public virtual SueldoVendedor IdSueldoVendedorNavigation { get; set; }
    }
}
