using Clinica.Medica.Application.DTOs;
using Clinica.Medica.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.Medica.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TriagemController : ControllerBase
{
    private readonly ITriagemService _service;

    public TriagemController(ITriagemService service) => _service = service;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TriagemDto dto)
    {
        var registrada = await _service.RegistrarAsync(dto);
        return Ok(registrada);
    }

    [HttpGet("buscar/{numero}")]
    public async Task<IActionResult> BuscarPorNumero(int numero)
    {
        var dados = await _service.BuscarDadosPacientePorNumeroAsync(numero);
        if (dados == null) return NotFound();
        return Ok(dados);
    }
}
