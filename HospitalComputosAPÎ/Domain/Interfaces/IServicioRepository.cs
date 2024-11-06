using computosApp.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IServicioRepository
    {
        Servicio? Get(string? name);
        List<Servicio> Get();
        int AddServicio (Servicio servicio);
    }
}
