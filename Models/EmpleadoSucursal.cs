using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class EmpleadoSucursal
    {
        public int IdEmpleadoSucursal { get; set; }
        public int IdTiendaSucursal { get; set; }
        public int IdEmpleado { get; set; }
        public int IdDepartamento { get; set; }
        public int IdVendedor { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual Departamento IdDepartamentoNavigation { get; set; }
        public virtual Empleado IdEmpleadoNavigation { get; set; }
        public virtual TiendaSucursal IdTiendaSucursalNavigation { get; set; }
        public virtual Vendedor IdVendedorNavigation { get; set; }
    }
}
