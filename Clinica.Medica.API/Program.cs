using Clinica.Medica.Application.Interfaces;
using Clinica.Medica.Application.Services;
using Clinica.Medica.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ClinicaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IAtendimentoService, AtendimentoService>();
builder.Services.AddScoped<ITriagemService, TriagemService>();
builder.Services.AddScoped<IEspecialidadeService, EspecialidadeService>();
builder.Services.AddScoped<IEstatisticaService, EstatisticaService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clinica.Medica.API v1");
    });
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
