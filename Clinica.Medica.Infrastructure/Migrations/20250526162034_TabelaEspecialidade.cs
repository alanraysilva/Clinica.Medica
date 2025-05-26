using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinica.Medica.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TabelaEspecialidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DtNascimento",
                table: "Pacientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Id);
                });

            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT 1 FROM Especialidades)
                BEGIN
                    INSERT INTO Especialidades (Id, Nome) VALUES
                    (1, 'Clínica Geral'),
                    (2, 'Cardiologia'),
                    (3, 'Dermatologia'),
                    (4, 'Endocrinologia'),
                    (5, 'Gastroenterologia'),
                    (6, 'Ginecologia'),
                    (7, 'Neurologia'),
                    (8, 'Ortopedia'),
                    (9, 'Pediatria'),
                    (10, 'Psiquiatria'),
                    (11, 'Urologia');
                END
                ELSE
                BEGIN
                    -- Garante que os dados existam (inserir ou atualizar)
                    MERGE INTO Especialidades AS target
                    USING (VALUES
                        (1, 'Clínica Geral'),
                        (2, 'Cardiologia'),
                        (3, 'Dermatologia'),
                        (4, 'Endocrinologia'),
                        (5, 'Gastroenterologia'),
                        (6, 'Ginecologia'),
                        (7, 'Neurologia'),
                        (8, 'Ortopedia'),
                        (9, 'Pediatria'),
                        (10, 'Psiquiatria'),
                        (11, 'Urologia')
                    ) AS source (Id, Nome)
                    ON target.Id = source.Id
                    WHEN MATCHED THEN
                        UPDATE SET Nome = source.Nome
                    WHEN NOT MATCHED THEN
                        INSERT (Id, Nome)
                        VALUES (source.Id, source.Nome);
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropColumn(
                name: "DtNascimento",
                table: "Pacientes");
        }


    }
}
