using Appplication_.Dtos;
using Appplication_.Services;
using computosApp.Models.DB;
using Microsoft.AspNetCore.Mvc;

namespace computosApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {

        private readonly ServicioServices _servicioServices; 
        
        public ServicioController(ServicioServices servicioService) 
        {
            _servicioServices = servicioService;
        }


        [HttpPost("agregarServicio")]
        public IActionResult AgregarServicio([FromBody] ServicioPostDto servicioPostDto)
        {
            if (servicioPostDto == null) 
            {
                return BadRequest("Los datos del servicio son nulos");
            }

            int newServicio = _servicioServices.AddServicio(servicioPostDto);

            return Ok("Servicio agregado correctamente");
        }
    }
}
