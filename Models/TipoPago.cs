using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class TipoPago
    {
        public TipoPago()
        {
            Cobro = new HashSet<Cobro>();
            PagoCompra = new HashSet<PagoCompra>();
        }

        public int IdTipoPago { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual ICollection<Cobro> Cobro { get; set; }
        public virtual ICollection<PagoCompra> PagoCompra { get; set; }
    }
}
