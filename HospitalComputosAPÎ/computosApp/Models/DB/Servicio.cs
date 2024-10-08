using System;
using System.Collections.Generic;

namespace computosApp.Models.DB
{
    public partial class Servicio
    {
        public Servicio()
        {
            Computadoras = new HashSet<Computadora>();
            EntregaToners = new HashSet<EntregaToner>();
        }

        public int IdServicio { get; set; }
        public string NombreServicio { get; set; } = null!;
        public string Descripción { get; set; } = null!;

        public virtual ICollection<Computadora> Computadoras { get; set; }
        public virtual ICollection<EntregaToner> EntregaToners { get; set; }
    }
}
