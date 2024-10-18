using computosApp.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITonerRepository
    {
        Toner? Get(string name);
        List<Toner> Get();
        int AddToner(Toner toner);
    }
}
