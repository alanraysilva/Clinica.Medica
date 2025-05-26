using Clinica.Medica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinica.Medica.Infrastructure.Configuration;

public class AtendimentoConfiguration : IEntityTypeConfiguration<Atendimento>
{
    public void Configure(EntityTypeBuilder<Atendimento> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.NumeroSequencial).IsRequired();
        builder.Property(a => a.DataHoraChegada).IsRequired();
        builder.Property(a => a.Status).HasMaxLength(50);

        builder.HasOne(a => a.Paciente)
               .WithMany(p => p.Atendimentos)
               .HasForeignKey(a => a.PacienteId);
    }
}