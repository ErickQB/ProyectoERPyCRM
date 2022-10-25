using System;
using System.Collections.Generic;
using System.ComponentModel;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class TipoCliente
    {
        public TipoCliente()
        {
            Cliente = new HashSet<Cliente>();
            Oferta = new HashSet<Oferta>();
            ProductoIdTipoClienteANavigation = new HashSet<Producto>();
            ProductoIdTipoClienteBNavigation = new HashSet<Producto>();
            ProductoIdTipoClienteCNavigation = new HashSet<Producto>();
            ProductoIdTipoClienteDNavigation = new HashSet<Producto>();
            ProductoIdTipoClienteENavigation = new HashSet<Producto>();
        }

        public int IdTipoCliente { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        [DisplayName("Fech. Creado")]
        public DateTime? FechaCreacion { get; set; }
        [DisplayName("Fech. Actualizado")]
        public DateTime? FechaActualizacion { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; }
        public virtual ICollection<Oferta> Oferta { get; set; }
        [DisplayName("Tipo Cliente A")]
        public virtual ICollection<Producto> ProductoIdTipoClienteANavigation { get; set; }
        [DisplayName("Tipo Cliente B")]
        public virtual ICollection<Producto> ProductoIdTipoClienteBNavigation { get; set; }
        [DisplayName("Tipo Cliente C")]
        public virtual ICollection<Producto> ProductoIdTipoClienteCNavigation { get; set; }
        [DisplayName("Tipo Cliente D")]
        public virtual ICollection<Producto> ProductoIdTipoClienteDNavigation { get; set; }
        [DisplayName("Tipo Cliente E")]
        public virtual ICollection<Producto> ProductoIdTipoClienteENavigation { get; set; }
    }
}
