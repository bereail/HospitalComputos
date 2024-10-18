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
    public class ServicioServices
    {
        private readonly IServicioRepository _repository;
        public ServicioServices(IServicioRepository repository)
        {
            _repository = repository;
        }

        public Servicio Get(string name)
        {
            return _repository.Get(name);
        }

        public List<Servicio> Get()
        {
            return _repository.Get();
        }
        public int AddServicio(ServicioPostDto servicioPostDto)
        {
            var servicio = new Servicio()
            {
                NombreServicio = servicioPostDto.NombreServicio,  // Usar newServicio para obtener el valor
                Descripción = string.IsNullOrWhiteSpace(servicioPostDto.Descripcion) ? null : servicioPostDto.Descripcion        // Usar newServicio para obtener el valor
            };

            return _repository.AddServicio(servicio);
        }

    }
}
