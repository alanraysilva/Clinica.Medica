using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Medica.Application.DTOs
{
    public record AtendimentoFilaDto(int Id, int NumeroSequencial, string PacienteNome);
}
