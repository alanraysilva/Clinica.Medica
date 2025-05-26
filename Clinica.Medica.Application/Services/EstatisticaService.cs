using Clinica.Medica.Application.DTOs;
using Clinica.Medica.Application.Interfaces;
using Clinica.Medica.Infrastructure;
using Microsoft.EntityFrameworkCore;


namespace Clinica.Medica.Application.Services
{
    public class EstatisticaService : IEstatisticaService
    {
        private readonly ClinicaDbContext _context;

        public EstatisticaService(ClinicaDbContext context) => _context = context;



        public async Task<List<AtividadeDto>> ListarUltimasAtividadesAsync()
        {
            var atividades = new List<AtividadeDto>();

            // Triagens realizadas
            var triagens = await _context.Triagens
                .Include(t => t.Atendimento)
                .ThenInclude(a => a.Paciente)
                .OrderByDescending(t => t.Id)
                .Take(5)
                .Select(t => new AtividadeDto(
                    $"Paciente {t.Atendimento.Paciente.Nome} foi chamado para triagem",
                    "triagem",
                    t.Atendimento.DataHoraChegada))
                .ToListAsync();

            atividades.AddRange(triagens);

            // Cadastros de pacientes
            var pacientes = await _context.Pacientes
                .OrderByDescending(p => p.Id)
                .Take(5)
                .Select(p => new AtividadeDto(
                    $"{p.Nome} foi cadastrado(a)",
                    "cadastro",
                    p.DataCadastro)) // precisa ter DataCadastro na entidade
                .ToListAsync();

            atividades.AddRange(pacientes);

            // Direcionamento para especialidade
            var especialidades = await _context.Triagens
                .Include(t => t.Atendimento)
                .ThenInclude(a => a.Paciente)
                .Include(t => t.Especialidade)
                .OrderByDescending(t => t.Id)
                .Take(5)
                .Select(t => new AtividadeDto(
                    $"{t.Atendimento.Paciente.Nome} foi direcionado para {t.Especialidade.Nome}",
                    "especialidade",
                    t.Atendimento.DataHoraChegada))
                .ToListAsync();

            atividades.AddRange(especialidades);

            // Ordenar por data (desc) e retornar os 5 mais recentes
            return atividades.OrderByDescending(a => a.DataHora).Take(5).ToList();
        }
    }
}
