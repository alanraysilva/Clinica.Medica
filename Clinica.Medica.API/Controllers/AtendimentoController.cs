using Clinica.Medica.Application.DTOs;
using Clinica.Medica.Application.Interfaces;
using Clinica.Medica.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.Medica.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AtendimentoController : ControllerBase
{
    private readonly IAtendimentoService _service;

    public AtendimentoController(IAtendimentoService service) => _service = service;

    [HttpGet("fila")]
    public async Task<IActionResult> GetFila() => Ok(await _service.ObterFilaAsync());

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AtendimentoDto dto)
    {
        var novo = await _service.CriarAsync(dto);
        return CreatedAtAction(nameof(GetFila), new { id = novo.Id }, novo);
    }

    [HttpGet("fila/simples")]
    public async Task<IActionResult> GetFilaSimplificada()
    {
        var fila = await _service.ObterFilaAsync();
        var resultado = fila.Select(f => new AtendimentoFilaDto(f.Id, f.NumeroSequencial, f.PacienteNome ?? ""));
        return Ok(resultado);
    }

    [HttpGet("fila/completa")]
    public async Task<IActionResult> GetFilaCompleta()
    {
        var atendimentos = await _service.ObterFilaCompletaAsync();
        return Ok(atendimentos);
    }

    [HttpPost("chamar/{id}")]
    public async Task<IActionResult> Chamar(int id)
    {
        await _service.MarcarComoEmAtendimentoAsync(id);
        return NoContent();
    }

    [HttpPost("finalizar/{id}")]
    public async Task<IActionResult> Finalizar(int id)
    {
        await _service.FinalizarAtendimentoAsync(id);
        return NoContent();
    }
}