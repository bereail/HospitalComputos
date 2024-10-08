using System;
using System.Collections.Generic;

namespace computosApp.Models.DB
{
    public partial class Reparacione
    {
        public int IdReparacion { get; set; }
        public int? IdComputadora { get; set; }
        public string Descripción { get; set; } = null!;
        public DateTime Fecha { get; set; }

        public virtual Computadora? IdComputadoraNavigation { get; set; }
    }
}
