using computosApp.Models.DB;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ServicioRepository : IServicioRepository
    {
        private readonly HospitalComputosContext _context;
        public ServicioRepository(HospitalComputosContext context)
        {
            _context = context;
        }

        public int AddServicio(Servicio servicio)
        {
            _context.Servicios.Add(servicio);
            _context.SaveChanges();
            return servicio.IdServicio;
        }

        public Servicio? Get(string name)
        {
            return _context.Servicios.FirstOrDefault(u => u.NombreServicio ==  name);
        }

        public List<Servicio> Get()
        {
            return _context.Servicios.ToList();
        }
    }
}
