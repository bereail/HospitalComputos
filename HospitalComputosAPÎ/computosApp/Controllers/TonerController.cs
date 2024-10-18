using Appplication_.Dtos;
using Appplication_.Services;
using Microsoft.AspNetCore.Mvc;

namespace computosApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TonerController : ControllerBase
    {
        private readonly TonerServices _tonerServices;

        public TonerController(TonerServices tonerService)
        {
            _tonerServices = tonerService;
        }


        [HttpPost("agregartoner")]
        public IActionResult AgregarToner([FromBody] TonerPostDto tonerPostDto)
        {
            if (tonerPostDto == null)
            {
                return BadRequest("Los datos del toner son nulos");
            }

            int newToner = _tonerServices.AddToner(tonerPostDto);

            return Ok("Servicio agregado correctamente");
        }
    }
}
