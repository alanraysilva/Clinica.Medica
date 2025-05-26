using Clinica.Medica.Application.DTOs;
using Clinica.Medica.Application.Interfaces;
using Clinica.Medica.Domain.Entities;
using Clinica.Medica.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Medica.Application.Services;

public class PacienteService : IPacienteService
{
    private readonly ClinicaDbContext _context;
    private readonly IAtendimentoService _atendimentoService;

    public PacienteService(ClinicaDbContext context, IAtendimentoService atendimentoService) 
    {
        _context = context;
        _atendimentoService = atendimentoService;
    } 

    public async Task<IEnumerable<PacienteDto>> ListarAsync()
        => await _context.Pacientes
            .Select(p => new PacienteDto(p.Id, p.Nome, p.DtNascimento, p.Telefone, p.Sexo, p.Email))
            .ToListAsync();

    public async Task<PacienteDto?> ObterPorIdAsync(int id)
    {
        var p = await _context.Pacientes.FindAsync(id);
        return p is null ? null : new PacienteDto(p.Id, p.Nome, p.DtNascimento, p.Telefone, p.Sexo, p.Email);
    }

    public async Task<PacienteDto> CriarAsync(PacienteDto dto)
    {
        var paciente = new Paciente(dto.Nome, dto.Dtnascimento, dto.Telefone, dto.Sexo, dto.Email);
        _context.Pacientes.Add(paciente);
        await _context.SaveChangesAsync();


        var atendimento = new AtendimentoDto(0, 0, paciente.Id, DateTime.Now, "Aguardando");
        _atendimentoService.CriarAsync(atendimento).Wait(); // Chama o serviço de atendimento para criar um novo atendimento    


        return new PacienteDto(paciente.Id, paciente.Nome, paciente.DtNascimento, paciente.Telefone, paciente.Sexo, paciente.Email);
    }
}
