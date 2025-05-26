using Clinica.Medica.Application.DTOs;

namespace Clinica.Medica.Application.Interfaces
{
    public interface IEspecialidadeService
    {
        Task<IEnumerable<EspecialidadeDto>> ListarAsync();
    }
}
