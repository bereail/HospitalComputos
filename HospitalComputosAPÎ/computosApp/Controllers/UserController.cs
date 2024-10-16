using Appplication_.Dtos;
using Appplication_.Services;
using Microsoft.AspNetCore.Mvc;

namespace computosApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly ServicioServices _service;

        // Constructor corregido
        public ServicioController(ServicioServices service)
        {
            _service = service;
        }

        // Método Get por nombre
        [HttpGet("{name}")]
        public IActionResult Get([FromRoute] string name)
        {
            // Corregido OkObjectResult a Ok
            return Ok(_service.Get(name));
        }

        // Método Get sin parámetros
        [HttpGet]
        public IActionResult Get()
        {
            // Corregido _servicio a _service
            return Ok(_service.Get());
        }

        // Método Post para añadir un servicio
        [HttpPost]
        public IActionResult Add([FromBody] ServicioForAddRequest body)
        {
            // Corregido para cerrar el método correctamente
            return Ok(_service.AddServicio(body));
        }
    }
}
