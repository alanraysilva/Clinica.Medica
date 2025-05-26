using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Medica.Application.Helpers
{
    public class Utilitarios
    {
        public static int CalcularIdade(DateTime dataNascimento) 
        {
            DateTime dataAtual = DateTime.Now; // 26/05/2025 15:21 -03
            int idade = dataAtual.Year - dataNascimento.Year;

            // Ajusta se o aniversário ainda não ocorreu este ano
            if (dataNascimento.Month > dataAtual.Month ||
                (dataNascimento.Month == dataAtual.Month && dataNascimento.Day > dataAtual.Day))
            {
                idade--;
            }

            return idade;
        }
    }
}
