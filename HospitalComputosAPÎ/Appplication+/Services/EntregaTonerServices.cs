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
    public class EntregaTonerServices
    {
        private readonly IEntregaTonerRespository _repository;
        public EntregaTonerServices(IEntregaTonerRespository repository)
        {
            _repository = repository;
        }

        public EntregaToner Get(int idEntregaToner)
        {
            return _repository.Get(idEntregaToner);
        }

        public List<EntregaToner> Get()
        {
            return _repository.Get();
        }
        public int AddEntregaToner(EntregaTonerPostDto entregaTonerPostDto)
        {
            var entregaToner = new EntregaToner()
            {
                IdToner = entregaTonerPostDto.IdToner,  // Usar newServicio para obtener el valor
                IdServicio = entregaTonerPostDto.IdServicio,
                Cantidad = entregaTonerPostDto.Cantidad// Usar newServicio para obtener el valor
            };

            return _repository.AddEntregaToner(entregaToner);
        }

    }
}
