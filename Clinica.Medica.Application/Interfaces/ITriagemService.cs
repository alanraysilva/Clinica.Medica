using Clinica.Medica.Application.DTOs;

namespace Clinica.Medica.Application.Interfaces
{
    public interface ITriagemService
    {
        Task<TriagemDto> RegistrarAsync(TriagemDto dto);
        Task<TriagemAtendimentoDto?> BuscarDadosPacientePorNumeroAsync(int numero);
    }

}
