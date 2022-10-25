using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class Bodega
    {
        public Bodega()
        {
            BodegaProducto = new HashSet<BodegaProducto>();
        }

        public int IdBodega { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public string Ubicacion { get; set; }
        public int? Capacidad { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual ICollection<BodegaProducto> BodegaProducto { get; set; }
    }
}
