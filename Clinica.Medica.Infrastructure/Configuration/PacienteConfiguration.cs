using Clinica.Medica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinica.Medica.Infrastructure.Configuration;

public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
{
    public void Configure(EntityTypeBuilder<Paciente> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Nome).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Telefone).HasMaxLength(15);
        builder.Property(p => p.Sexo).HasMaxLength(1);
        builder.Property(p => p.Email).HasMaxLength(100);
    }
}
