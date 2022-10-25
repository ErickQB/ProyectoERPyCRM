using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class Vehiculos
    {
        public Vehiculos()
        {
            TransporteEntrega = new HashSet<TransporteEntrega>();
        }

        public int IdVehiculo { get; set; }
        public string Tipo { get; set; }
        public string Uso { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Linea { get; set; }
        public string Placa { get; set; }
        public string Chasis { get; set; }
        public string Serie { get; set; }
        public string Color { get; set; }
        public int Asientos { get; set; }
        public int Cilindraje { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

        public virtual ICollection<TransporteEntrega> TransporteEntrega { get; set; }
    }
}
