using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            CotizacionCompra = new HashSet<CotizacionCompra>();
            Producto = new HashSet<Producto>();
        }

        public int IdProveedor { get; set; }
        public string Tipo { get; set; }
        public string RazonSocial { get; set; }
        public string Nit { get; set; }
        public string Direccion { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public string NombreContacto { get; set; }
        public string DespachoLocal { get; set; }
        public string Envio { get; set; }
        public string ClasificacionProveedor { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual ICollection<CotizacionCompra> CotizacionCompra { get; set; }
        public virtual ICollection<Producto> Producto { get; set; }
    }
}
