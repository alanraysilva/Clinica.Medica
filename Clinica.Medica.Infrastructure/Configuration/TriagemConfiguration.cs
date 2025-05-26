using Clinica.Medica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinica.Medica.Infrastructure.Configuration;

public class TriagemConfiguration : IEntityTypeConfiguration<Triagem>
{
    public void Configure(EntityTypeBuilder<Triagem> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Sintomas).HasMaxLength(500);
        builder.Property(t => t.PressaoArterial).HasMaxLength(10);

        builder.HasOne(t => t.Atendimento)
               .WithOne(a => a.Triagem)
               .HasForeignKey<Triagem>(t => t.AtendimentoId);
    }
}
