namespace Clinica.Medica.Application.DTOs
{
    public record AtendimentoDto(int Id, int NumeroSequencial, int PacienteId, DateTime DataHoraChegada, string Status, string? PacienteNome = null);
    public record AtendimentosDto(int Id, int NumeroSequencial, string PacienteNome, string Especialidade, DateTime DataHoraChegada, string Status, bool Prioritario);
}
