using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class Oferta
    {
        public int IdOferta { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public int IdProducto { get; set; }
        public int PorcentajeDescuento { get; set; }
        public int IdTipoCliente { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
        public virtual TipoCliente IdTipoClienteNavigation { get; set; }
    }
}
