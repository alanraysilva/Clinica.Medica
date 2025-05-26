using Clinica.Medica.Domain.Enuns;

namespace Clinica.Medica.Domain.Entities
{
    public class Atendimento
    {
        public int Id { get; private set; }
        public int NumeroSequencial { get; private set; }
        public int PacienteId { get; private set; }
        public DateTime DataHoraChegada { get; private set; }

        public string Status { get; private set; } = StatusAtendimento.Aguardando;

        public Paciente Paciente { get; private set; } = null!;
        public Triagem? Triagem { get; private set; }

        protected Atendimento() { } // EF

        public Atendimento(int numeroSequencial, int pacienteId, DateTime dataHoraChegada)
        {
            NumeroSequencial = numeroSequencial;
            PacienteId = pacienteId;
            DataHoraChegada = dataHoraChegada;
            Status = StatusAtendimento.Aguardando;
        }

        public void MarcarComoEmAtendimento()
        {
            Status = StatusAtendimento.EmAtendimento;
        }

        public void Finalizar()
        {
            Status = StatusAtendimento.Finalizado;
        }

        public void Encerrar()
        {
            Status = StatusAtendimento.Triagem; // Usado após triagem
        }
    }

    public static class StatusAtendimento
    {
        public const string Aguardando = "Aguardando";
        public const string EmAtendimento = "EmAtendimento";
        public const string Finalizado = "Finalizado";
        public const string Triagem = "Triagem";
    }

}
