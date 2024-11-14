using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstudosApi.Migrations
{
    /// <inheritdoc />
    public partial class Correcao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DtaAcesso",
                table: "TB_ALUNOS",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TB_ALUNOS",
                keyColumn: "Id",
                keyValue: 1,
                column: "DtaAcesso",
                value: null);

            migrationBuilder.UpdateData(
                table: "TB_ALUNOS",
                keyColumn: "Id",
                keyValue: 2,
                column: "DtaAcesso",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DtaAcesso",
                table: "TB_ALUNOS");
        }
    }
}
