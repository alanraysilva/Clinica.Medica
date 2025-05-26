using Clinica.Medica.Application.DTOs;

namespace Clinica.Medica.Application.Interfaces
{
    public interface IEstatisticaService
    {
        Task<List<AtividadeDto>> ListarUltimasAtividadesAsync();
    }
}
