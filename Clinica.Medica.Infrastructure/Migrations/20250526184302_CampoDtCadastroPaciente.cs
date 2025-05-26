using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinica.Medica.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CampoDtCadastroPaciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Pacientes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Triagens_EspecialidadeId",
                table: "Triagens",
                column: "EspecialidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Triagens_Especialidades_EspecialidadeId",
                table: "Triagens",
                column: "EspecialidadeId",
                principalTable: "Especialidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Triagens_Especialidades_EspecialidadeId",
                table: "Triagens");

            migrationBuilder.DropIndex(
                name: "IX_Triagens_EspecialidadeId",
                table: "Triagens");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Pacientes");
        }
    }
}
