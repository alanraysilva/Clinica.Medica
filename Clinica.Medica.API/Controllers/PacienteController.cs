using Clinica.Medica.Application.DTOs;
using Clinica.Medica.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.Medica.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PacienteController : ControllerBase
{
    private readonly IPacienteService _service;

    public PacienteController(IPacienteService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _service.ListarAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var paciente = await _service.ObterPorIdAsync(id);
        return paciente == null ? NotFound() : Ok(paciente);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PacienteDto dto)
    {
        var novo = await _service.CriarAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = novo.Id }, novo);
    }
}
