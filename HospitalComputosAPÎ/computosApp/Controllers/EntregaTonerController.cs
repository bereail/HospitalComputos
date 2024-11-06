using Appplication_.Dtos;
using Appplication_.Services;
using Microsoft.AspNetCore.Mvc;

namespace computosApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntregaTonerController : ControllerBase
    {

        private readonly EntregaTonerServices _entregaTonerServices;

        public EntregaTonerController(EntregaTonerServices entregaTonerService)
        {
            _entregaTonerServices = entregaTonerService;
        }


        [HttpPost("nuevaEntregaToner")]
        public IActionResult NuevaEntregaToner([FromBody] EntregaTonerPostDto entregaTonerPostDto)
        {
            if (entregaTonerPostDto == null)
            {
                return BadRequest("Los datos son nulos");
            }

            int newEntregaToner = _entregaTonerServices.AddEntregaToner(entregaTonerPostDto);

            return Ok("Entrega de toner agregada correctamente");
        }
    }
}
