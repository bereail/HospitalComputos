using System;
using System.Collections.Generic;

namespace computosApp.Models.DB
{
    public partial class Impresora
    {
        public int IdImpresora { get; set; }
        public string NombreImpresora { get; set; } = null!;
        public int? IdComputadora { get; set; }
        public int? IdToner { get; set; }

        public virtual Computadora? IdComputadoraNavigation { get; set; }
        public virtual Toner? IdTonerNavigation { get; set; }
    }
}
