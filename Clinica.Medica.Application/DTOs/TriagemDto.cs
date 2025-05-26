namespace Clinica.Medica.Application.DTOs
{
    public record TriagemDto(int Id, int AtendimentoId, string Sintomas, string PressaoArterial, double Peso, double Altura, int EspecialidadeId, bool Prioritario);
    public record TriagemAtendimentoDto(int AtendimentoId, string Nome, string Sexo, int Idade, string Telefone, bool prioritario);
}
