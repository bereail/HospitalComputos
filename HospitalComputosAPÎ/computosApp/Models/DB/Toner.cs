using System;
using System.Collections.Generic;

namespace computosApp.Models.DB
{
    public partial class Toner
    {
        public Toner()
        {
            EntregaToners = new HashSet<EntregaToner>();
            Impresoras = new HashSet<Impresora>();
        }

        public int IdToner { get; set; }
        public string Nombre { get; set; } = null!;
        public int Cantidad { get; set; }

        public virtual ICollection<EntregaToner> EntregaToners { get; set; }
        public virtual ICollection<Impresora> Impresoras { get; set; }
    }
}
