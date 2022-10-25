using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            EmpleadoSucursal = new HashSet<EmpleadoSucursal>();
            Inventario = new HashSet<Inventario>();
            InventarioIngresoManual = new HashSet<InventarioIngresoManual>();
            SueldoEmpleado = new HashSet<SueldoEmpleado>();
            TransporteEntrega = new HashSet<TransporteEntrega>();
            Vendedor = new HashSet<Vendedor>();
        }

        public int IdEmpleado { get; set; }
        public string CodigoEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
        public string Foto { get; set; }
        public string CorreoElectronico { get; set; }
        public string NoTelefono { get; set; }
        public string TituloAlcanzado { get; set; }
        public string Direccion { get; set; }
        public string Nit { get; set; }
        public string Igss { get; set; }
        public string Licencia { get; set; }
        public string NoLicencia { get; set; }
        public string TipoLicencia { get; set; }
        public float? SueldoDevengado { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual ICollection<EmpleadoSucursal> EmpleadoSucursal { get; set; }
        public virtual ICollection<Inventario> Inventario { get; set; }
        public virtual ICollection<InventarioIngresoManual> InventarioIngresoManual { get; set; }
        public virtual ICollection<SueldoEmpleado> SueldoEmpleado { get; set; }
        public virtual ICollection<TransporteEntrega> TransporteEntrega { get; set; }
        public virtual ICollection<Vendedor> Vendedor { get; set; }
    }
}
