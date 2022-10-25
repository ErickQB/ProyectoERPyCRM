using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class TiendaSucursal
    {
        public TiendaSucursal()
        {
            EmpleadoSucursal = new HashSet<EmpleadoSucursal>();
        }

        public int IdTiendaSucursal { get; set; }
        public int IdTienda { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int IdEmpleadoEncargado { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual Tienda IdTiendaNavigation { get; set; }
        public virtual ICollection<EmpleadoSucursal> EmpleadoSucursal { get; set; }
    }
}
