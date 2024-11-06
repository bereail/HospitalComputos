using computosApp.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IEntregaTonerRespository
    {
        EntregaToner? Get(int idEntregaToner);
        List<EntregaToner> Get();
        int AddEntregaToner(EntregaToner entregaToner);
    }
}
