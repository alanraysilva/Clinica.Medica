using Clinica.Medica.Application.DTOs;

namespace Clinica.Medica.Application.Interfaces
{
    public interface IPacienteService
    {
        Task<IEnumerable<PacienteDto>> ListarAsync();
        Task<PacienteDto?> ObterPorIdAsync(int id);
        Task<PacienteDto> CriarAsync(PacienteDto dto);
    }

}
