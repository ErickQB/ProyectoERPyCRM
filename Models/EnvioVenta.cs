using System;
using System.Collections.Generic;
using System.ComponentModel;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class EnvioVenta
    {
        public int IdEnvioVenta { get; set; }
        [DisplayName("Despacho")]
        public int IdDespacho { get; set; }
        [DisplayName("Transporte")]
        public int IdTransporteEntrega { get; set; }
        [DisplayName("Fecha Salida")]
        public DateTime DiaSalida { get; set; }
        [DisplayName("Hora Salida")]
        public TimeSpan HoraSalida { get; set; }
        [DisplayName("Fecha Entrega")]
        public DateTime? DiaEntrega { get; set; }
        [DisplayName("Hora Entrega")]
        public TimeSpan? HoraEntrega { get; set; }
        [DisplayName("Direccion Entrega")]
        public string DireccionEntrega { get; set; }
        [DisplayName("Tipo Envio")]
        public string TipoEnvio { get; set; }
        [DisplayName("Recibido Por")]
        public string ContactoRecibir { get; set; }
        public string Estado { get; set; }
        [DisplayName("Fecha Creado")]
        public DateTime? FechaCreacion { get; set; }
        [DisplayName("Fecha Actualizado")]
        public DateTime? FechaActualizacion { get; set; }


        [DisplayName("Despacho")]
        public virtual Despacho IdDespachoNavigation { get; set; }
        [DisplayName("Transporte")]
        public virtual TransporteEntrega IdTransporteEntregaNavigation { get; set; }
    }
}
