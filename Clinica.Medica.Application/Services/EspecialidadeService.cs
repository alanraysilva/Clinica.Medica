using Clinica.Medica.Application.DTOs;
using Clinica.Medica.Application.Interfaces;
using Clinica.Medica.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Medica.Application.Services
{
    public class EspecialidadeService : IEspecialidadeService
    {
        private readonly ClinicaDbContext _context;

        public EspecialidadeService(ClinicaDbContext context) => _context = context;

        public async Task<IEnumerable<EspecialidadeDto>> ListarAsync()
        {
            return await _context.Especialidades.Select(e => new EspecialidadeDto(e.Id, e.Nome)).ToListAsync();
        }
    }
}
