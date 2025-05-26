using Clinica.Medica.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Medica.Infrastructure;

public class ClinicaDbContext : DbContext
{
    public DbSet<Paciente> Pacientes => Set<Paciente>();
    public DbSet<Atendimento> Atendimentos => Set<Atendimento>();
    public DbSet<Triagem> Triagens => Set<Triagem>();
    public DbSet<Especialidade> Especialidades => Set<Especialidade>();

    public ClinicaDbContext(DbContextOptions<ClinicaDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClinicaDbContext).Assembly);
    }
}