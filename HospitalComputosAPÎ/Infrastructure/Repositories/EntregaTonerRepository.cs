using computosApp.Models.DB;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EntregaTonerRepository : IEntregaTonerRespository
    {
        private readonly HospitalComputosContext _context;

        public EntregaTonerRepository(HospitalComputosContext context)
        {
            _context = context;
        }

        public int AddEntregaToner(EntregaToner entregaToner)
        {

            _context.EntregaToners.Add(entregaToner);
            _context.SaveChanges();
            return entregaToner.IdToner;
        }

        public EntregaToner? Get(int idEntregaToner)
        {
            return _context.EntregaToners.FirstOrDefault(u => u.IdEntregaToner == idEntregaToner);
        }

        public List<EntregaToner> Get()
        {
            return _context.EntregaToners.ToList();
        }
    }
}
