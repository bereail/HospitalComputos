using Appplication_.Dtos;
using computosApp.Models.DB;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appplication_.Services
{
    public class TonerServices
    {
        private readonly ITonerRepository _repository;
        public TonerServices(ITonerRepository repository)
        {
            _repository = repository;
        }

        public Toner Get(string name)
        {
            return _repository.Get(name);
        }

        public List<Toner> Get()
        {
            return _repository.Get();
        }
        public int AddToner(TonerPostDto tonerPostDto)
        {
            var toner = new Toner()
            {
                Nombre = tonerPostDto.Nombre,  
                Cantidad =  tonerPostDto.Cantidad        
            };

            return _repository.AddToner(toner);
        }

    }
}
