using System;
using System.Collections.Generic;

namespace computosApp.Models.DB
{
    public partial class EntregaToner
    {
        public int IdEntregaToner { get; set; }
        public int IdToner { get; set; }
        public int Cantidad { get; set; }
        public string? Descripcion { get; set; }
        public int? IdServicio { get; set; }

        public virtual Servicio? IdServicioNavigation { get; set; }
        public virtual Toner IdTonerNavigation { get; set; } = null!;
    }
}
