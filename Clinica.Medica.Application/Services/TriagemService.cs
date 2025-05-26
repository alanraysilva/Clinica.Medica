using Clinica.Medica.Application.DTOs;
using Clinica.Medica.Application.Helpers;
using Clinica.Medica.Application.Interfaces;
using Clinica.Medica.Domain.Entities;
using Clinica.Medica.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Medica.Application.Services;

public class TriagemService : ITriagemService
{
    private readonly ClinicaDbContext _context;

    public TriagemService(ClinicaDbContext context) => _context = context;

    public async Task<TriagemAtendimentoDto?> BuscarDadosPacientePorNumeroAsync(int numero)
    {
        var atendimento = await _context.Atendimentos
            .Include(a => a.Paciente)
            .FirstOrDefaultAsync(a => a.NumeroSequencial == numero);

        if (atendimento == null)
            return null;

        var paciente = atendimento.Paciente;

        // Calcular idade fictícia por enquanto
        int idade = Utilitarios.CalcularIdade(paciente.DtNascimento);

        return new TriagemAtendimentoDto(
            atendimento.Id,      // <- ID REAL DO ATENDIMENTO
            paciente.Nome,
            paciente.Sexo,
            idade,
            paciente.Telefone,
            idade > 60 ? true : false // Prioritário se maior de 60 anos
        );
    }

    public async Task<TriagemDto> RegistrarAsync(TriagemDto dto)
    {
        var triagem = new Triagem(dto.AtendimentoId, dto.Sintomas, dto.PressaoArterial, dto.Peso, dto.Altura, dto.EspecialidadeId, dto.Prioritario);
        _context.Triagens.Add(triagem);

        var atendimento = await _context.Atendimentos.FindAsync(dto.AtendimentoId);
        if (atendimento != null)
        {
            atendimento.Encerrar(); // Atualiza o status via método de domínio
        }

        await _context.SaveChangesAsync();

        return new TriagemDto(triagem.Id, triagem.AtendimentoId, triagem.Sintomas, triagem.PressaoArterial, triagem.Peso, triagem.Altura, triagem.EspecialidadeId, triagem.Prioritario);
    }
}
