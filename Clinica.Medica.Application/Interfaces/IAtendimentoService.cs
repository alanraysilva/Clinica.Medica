using Clinica.Medica.Application.DTOs;

namespace Clinica.Medica.Application.Interfaces
{
    public interface IAtendimentoService
    {
        Task<IEnumerable<AtendimentoDto>> ObterFilaAsync();
        Task<AtendimentoDto> CriarAsync(AtendimentoDto dto);
        Task<IEnumerable<AtendimentosDto>> ObterFilaCompletaAsync();
        Task MarcarComoEmAtendimentoAsync(int id);
        Task FinalizarAtendimentoAsync(int id);
    }

}
