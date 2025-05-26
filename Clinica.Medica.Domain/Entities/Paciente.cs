namespace Clinica.Medica.Domain.Entities
{
    public class Paciente
    {
        public int Id { get; private set; }
        public string Nome { get; private set; } = "";
        public DateTime DtNascimento { get; private set; } // Formato: dd/MM/yyyy
        public string Telefone { get; private set; } = "";
        public string Sexo { get; private set; } = ""; // M/F
        public string Email { get; private set; } = "";
        public DateTime DataCadastro { get; private set; } = DateTime.Now;
        public ICollection<Atendimento> Atendimentos { get; private set; } = new List<Atendimento>();


        protected Paciente() { } // EF

        public Paciente(string nome, DateTime dtnascimento,string telefone, string sexo, string email)
        {
            Nome = nome;
            DtNascimento = dtnascimento;
            Telefone = telefone;
            Sexo = sexo;
            Email = email;
            DataCadastro = DateTime.Now;
        }
    }
}
