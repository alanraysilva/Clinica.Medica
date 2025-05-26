using Clinica.Medica.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.Medica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadeController : ControllerBase
    {
        private readonly IEspecialidadeService _service;

        public EspecialidadeController(IEspecialidadeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lista = await _service.ListarAsync();
            return Ok(lista);
        }
    }
}
