using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Medica.Domain.Entities
{
    public class Especialidade
    {
        public int Id { get; private set; }
        public string Nome { get; private set; } = string.Empty;

        public Especialidade(){}

        public Especialidade(int id, string nome)
        {
            Id = id;
            Nome = nome ?? throw new ArgumentNullException(nameof(nome), "Nome não pode ser nulo.");
        }


    }
}
