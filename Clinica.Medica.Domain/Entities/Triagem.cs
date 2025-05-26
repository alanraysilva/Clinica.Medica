namespace Clinica.Medica.Domain.Entities
{
    public class Triagem
    {
        public int Id { get; private set; }
        public int AtendimentoId { get; private set; }
        public string Sintomas { get; private set; }
        public string PressaoArterial { get; private set; }
        public double Peso { get; private set; }
        public double Altura { get; private set; }
        public int EspecialidadeId { get; private set; }
        public bool Prioritario { get; private set; } = false;

        public Atendimento Atendimento { get; private set; } = null!;
        public Especialidade Especialidade { get; private set; } = null!;

        protected Triagem() { } // EF

        public Triagem(int atendimentoId, string sintomas, string pressaoArterial, double peso, double altura, int especialidadeId, bool prioritario)
        {
            AtendimentoId = atendimentoId;
            Sintomas = sintomas;
            PressaoArterial = pressaoArterial;
            Peso = peso;
            Altura = altura;
            EspecialidadeId = especialidadeId;
            Prioritario = prioritario;
        }
    }
}
