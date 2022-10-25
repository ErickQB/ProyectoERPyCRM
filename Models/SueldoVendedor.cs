using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class SueldoVendedor
    {
        public SueldoVendedor()
        {
            PagoPlanilla = new HashSet<PagoPlanilla>();
        }

        public int IdSueldoVendedor { get; set; }
        public DateTime Mes { get; set; }
        public DateTime Anio { get; set; }
        public int IdVendedor { get; set; }
        public float TotalVenta { get; set; }
        public float? TotalComision { get; set; }
        public float? Descuento { get; set; }
        public float TotalPago { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual Vendedor IdVendedorNavigation { get; set; }
        public virtual ICollection<PagoPlanilla> PagoPlanilla { get; set; }
    }
}
