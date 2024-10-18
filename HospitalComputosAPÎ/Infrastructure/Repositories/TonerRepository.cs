using computosApp.Models.DB;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TonerRepository : ITonerRepository
    {
        private readonly HospitalComputosContext _context;

        public TonerRepository(HospitalComputosContext context)
        {
            _context = context;
        }
        public int AddToner(Toner toner)
        {
            _context.Toners.Add(toner);
            _context.SaveChanges();
            return toner.IdToner;
        }

        public Toner? Get(string name)
        {
           return _context.Toners.FirstOrDefault(u => u.Nombre == name);
        }

        public List<Toner> Get()
        {
            return _context.Toners.ToList();
        }
    }
}


