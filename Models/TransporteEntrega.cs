using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class TransporteEntrega
    {
        public TransporteEntrega()
        {
            EnvioVenta = new HashSet<EnvioVenta>();
        }

        public int IdTransporteEntrega { get; set; }
        public int IdVehiculo { get; set; }
        public int IdConductor { get; set; }
        public TimeSpan HoraSalida { get; set; }
        public DateTime FechaSalida { get; set; }
        public TimeSpan? HoraRegreso { get; set; }
        public DateTime? FechaRegreso { get; set; }
        public int KilometrajeSalida { get; set; }
        public int? KilometrajeEntrada { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual Empleado IdConductorNavigation { get; set; }
        public virtual Vehiculos IdVehiculoNavigation { get; set; }
        public virtual ICollection<EnvioVenta> EnvioVenta { get; set; }
    }
}
