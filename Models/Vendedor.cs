using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class Vendedor
    {
        public Vendedor()
        {
            CotizacionVenta = new HashSet<CotizacionVenta>();
            EmpleadoSucursal = new HashSet<EmpleadoSucursal>();
            FacturaVenta = new HashSet<FacturaVenta>();
            SueldoVendedor = new HashSet<SueldoVendedor>();
        }

        public int IdVendedor { get; set; }
        public string Codigo { get; set; }
        public int IdEmpleado { get; set; }
        public int? ComisionVenta { get; set; }
        public string Especializacion { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual Empleado IdEmpleadoNavigation { get; set; }
        public virtual ICollection<CotizacionVenta> CotizacionVenta { get; set; }
        public virtual ICollection<EmpleadoSucursal> EmpleadoSucursal { get; set; }
        public virtual ICollection<FacturaVenta> FacturaVenta { get; set; }
        public virtual ICollection<SueldoVendedor> SueldoVendedor { get; set; }
    }
}
