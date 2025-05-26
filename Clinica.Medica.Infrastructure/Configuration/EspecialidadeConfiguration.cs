using Clinica.Medica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Medica.Infrastructure.Configuration
{
    public class EspecialidadeConfiguration : IEntityTypeConfiguration<Especialidade>
    {
        public void Configure(EntityTypeBuilder<Especialidade> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Nome).IsRequired();
        }
    }
}