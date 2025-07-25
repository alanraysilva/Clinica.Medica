﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinica.Medica.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NovosCamposTriagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Prioritario",
                table: "Triagens",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prioritario",
                table: "Triagens");
        }
    }
}
