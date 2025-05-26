using Clinica.Medica.Application.Interfaces;
using Clinica.Medica.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Medica.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EstatisticasController : ControllerBase
{
    private readonly ClinicaDbContext _context;
    private readonly IEstatisticaService _estatisticaService;

    public EstatisticasController(ClinicaDbContext context, IEstatisticaService estatisticaService)
    {
        _context = context;
        _estatisticaService = estatisticaService;
    }

    [HttpGet("total-pacientes")]
    public async Task<int> GetTotalPacientes()
    {
        return await _context.Pacientes.CountAsync();
    }

    [HttpGet("fila")]
    public async Task<int> GetFila()
    {
        return await _context.Atendimentos.CountAsync(x => x.Status == "Aguardando" || x.Status == "Triagem");
    }

    [HttpGet("em-atendimento")]
    public async Task<int> GetEmAtendimento()
    {
        return await _context.Atendimentos.CountAsync(x => x.Status == "EmAtendimento");
    }

    [HttpGet("atendidos-hoje")]
    public async Task<int> GetAtendidosHoje()
    {
        var hoje = DateTime.Today;
        return await _context.Triagens
            .Include(t => t.Atendimento)
            .CountAsync(t => t.Atendimento.DataHoraChegada.Date == hoje);
    }

    [HttpGet("ultimas-atividades")]
    public async Task<IActionResult> UltimasAtividades()
    {
        var lista = await _estatisticaService.ListarUltimasAtividadesAsync();
        return Ok(lista);
    }
}
