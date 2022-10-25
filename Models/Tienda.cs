using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class Tienda
    {
        public Tienda()
        {
            TiendaSucursal = new HashSet<TiendaSucursal>();
        }

        public int IdTienda { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string RazonSocial { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual ICollection<TiendaSucursal> TiendaSucursal { get; set; }
    }
}
