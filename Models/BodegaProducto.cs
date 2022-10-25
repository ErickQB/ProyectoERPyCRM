using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class BodegaProducto
    {
        public BodegaProducto()
        {
            InventarioBodegaProducto = new HashSet<InventarioBodegaProducto>();
        }

        public int IdBodegaProducto { get; set; }
        public int IdBodega { get; set; }
        public int IdProducto { get; set; }
        public int NoEdificio { get; set; }
        public int? Nivel { get; set; }
        public string Habitacion { get; set; }
        public string Estanteria { get; set; }
        public string NivelEstanteria { get; set; }
        public string PosicionEstanteria { get; set; }
        public float Cantidad { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual Bodega IdBodegaNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
        public virtual ICollection<InventarioBodegaProducto> InventarioBodegaProducto { get; set; }
    }
}
