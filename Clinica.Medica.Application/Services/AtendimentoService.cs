using Clinica.Medica.Application.DTOs;
using Clinica.Medica.Application.Interfaces;
using Clinica.Medica.Domain.Entities;
using Clinica.Medica.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Medica.Application.Services;

public class AtendimentoService : IAtendimentoService
{
    private readonly ClinicaDbContext _context;

    public AtendimentoService(ClinicaDbContext context) => _context = context;

    public async Task<IEnumerable<AtendimentoDto>> ObterFilaAsync()
    {
        return await _context.Atendimentos
            .Where(a => a.Status == StatusAtendimento.Aguardando)
            .Include(a => a.Paciente)
            .Select(a => new AtendimentoDto(
                a.Id,
                a.NumeroSequencial,
                a.PacienteId,
                a.DataHoraChegada,
                a.Status,
                a.Paciente.Nome))
            .ToListAsync();
    }

    public async Task<AtendimentoDto> CriarAsync(AtendimentoDto dto)
    {
        var novoNumero = await _context.Atendimentos.MaxAsync(a => (int?)a.NumeroSequencial) ?? 0;

        var atendimento = new Atendimento(novoNumero + 1, dto.PacienteId, dto.DataHoraChegada);
        _context.Atendimentos.Add(atendimento);
        await _context.SaveChangesAsync();

        return new AtendimentoDto(atendimento.Id, atendimento.NumeroSequencial, atendimento.PacienteId, atendimento.DataHoraChegada, atendimento.Status);
    }



    public async Task MarcarComoEmAtendimentoAsync(int id)
    {
        var atendimento = await _context.Atendimentos.FindAsync(id);
        if (atendimento is not null)
        {
            atendimento.MarcarComoEmAtendimento();
            await _context.SaveChangesAsync();
        }
    }

    public async Task FinalizarAtendimentoAsync(int id)
    {
        var atendimento = await _context.Atendimentos.FindAsync(id);
        if (atendimento is not null)
        {
            atendimento.Finalizar();
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<AtendimentosDto>> ObterFilaCompletaAsync()
    {
        return await _context.Atendimentos
                .Include(x => x.Paciente)
                .Include(x => x.Triagem)
                .ThenInclude(t => t.Especialidade)
                .OrderBy(x => x.DataHoraChegada)
                .Select(x => new AtendimentosDto(
                    x.Id,
                    x.NumeroSequencial,
                    x.Paciente.Nome,
                    x.Triagem != null ? x.Triagem.Especialidade.Nome : "Não definida",
                    x.DataHoraChegada,
                    x.Status,
                    x.Triagem != null && x.Triagem.Prioritario)) // Prioridade fictícia
                .ToListAsync();
    }
}