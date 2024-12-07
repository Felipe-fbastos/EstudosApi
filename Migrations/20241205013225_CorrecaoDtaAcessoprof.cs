using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstudosApi.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoDtaAcessoprof : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DtaAcesso",
                table: "TB_PROFESSORES",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TB_PROFESSORES",
                keyColumn: "Id",
                keyValue: 1,
                column: "DtaAcesso",
                value: null);

            migrationBuilder.UpdateData(
                table: "TB_PROFESSORES",
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
                table: "TB_PROFESSORES");
        }
    }
}
