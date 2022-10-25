using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ProyectoX.Models
{
    public partial class Configuracion
    {
        public float? TipoCambioDolar { get; set; }
        public float? TipoCambioPesosMexicanos { get; set; }
        public string RutaFotoEmpleado { get; set; }
        public string RutaFotoProducto { get; set; }
    }
}
