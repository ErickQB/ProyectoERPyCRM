using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class InventarioBodegaProducto
    {
        public int IdInventarioBodegaProducto { get; set; }
        public int IdBodegaProducto { get; set; }
        public int IdInventario { get; set; }
        public float Cantidad { get; set; }
        public string SinCambio { get; set; }
        public string Observaciones { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual BodegaProducto IdBodegaProductoNavigation { get; set; }
        public virtual Inventario IdInventarioNavigation { get; set; }
    }
}
