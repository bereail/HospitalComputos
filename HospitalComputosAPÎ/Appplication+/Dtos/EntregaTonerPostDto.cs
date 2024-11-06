using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appplication_.Dtos
{
    public class EntregaTonerPostDto
    {
        public int IdToner { get; set; }
        public int Cantidad { get; set; }
        public string? Descripcion { get; set; }
        public int? IdServicio { get; set; }

    }
}
