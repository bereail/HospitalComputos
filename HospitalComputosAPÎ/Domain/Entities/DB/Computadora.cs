using System;
using System.Collections.Generic;

namespace computosApp.Models.DB
{
    public partial class Computadora
    {
        public Computadora()
        {
            Impresoras = new HashSet<Impresora>();
            Reparaciones = new HashSet<Reparacione>();
        }

        public int IdComputadora { get; set; }
        public string NombrePc { get; set; } = null!;
        public string Ip { get; set; } = null!;
        public int? IdServicio { get; set; }
        public string Usuario { get; set; } = null!;
        public string NombreUsuario { get; set; } = null!;

        public virtual Servicio? IdServicioNavigation { get; set; }
        public virtual ICollection<Impresora> Impresoras { get; set; }
        public virtual ICollection<Reparacione> Reparaciones { get; set; }
    }
}
