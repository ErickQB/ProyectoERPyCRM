using System;
using System.Collections.Generic;
using System.ComponentModel;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class Despacho
    {
        public Despacho()
        {
            EnvioVenta = new HashSet<EnvioVenta>();
        }

        public int IdDespacho { get; set; }
        [DisplayName("Factura")]
        public int IdFactura { get; set; }
        public DateTime Fecha { get; set; }
        [DisplayName("Fecha Salida")]
        public DateTime DiaSalida { get; set; }
        [DisplayName("Hora Salida")]
        public TimeSpan HoraSalida { get; set; }
        [DisplayName("Lugar Despacho")]
        public string LugarDespacho { get; set; }
        public string Estado { get; set; }
        [DisplayName("Fech. Creado")]
        public DateTime? FechaCreacion { get; set; }
        [DisplayName("Fech. Actualizado")]
        public DateTime? FechaActualizacion { get; set; }
        
        [DisplayName("Factura")]
        public virtual FacturaVenta IdFacturaNavigation { get; set; }
        [DisplayName("Envio")]
        public virtual ICollection<EnvioVenta> EnvioVenta { get; set; }
    }
}
