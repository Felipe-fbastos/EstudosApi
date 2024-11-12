using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EstudosApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_ALUNOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtaNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ALUNOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PROFESSORES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtaNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PROFESSORES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_MATERIAS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HorasDoCurso = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusMateria = table.Column<int>(type: "int", nullable: false),
                    IdProfessor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MATERIAS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_MATERIAS_TB_PROFESSORES_IdProfessor",
                        column: x => x.IdProfessor,
                        principalTable: "TB_PROFESSORES",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TB_MATRICULAS",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    MateriaId = table.Column<int>(type: "int", nullable: false),
                    DataMatricula = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MATRICULAS", x => new { x.AlunoId, x.MateriaId });
                    table.ForeignKey(
                        name: "FK_TB_MATRICULAS_TB_ALUNOS_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "TB_ALUNOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_MATRICULAS_TB_MATERIAS_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "TB_MATERIAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_ALUNOS",
                columns: new[] { "Id", "Cpf", "DtaNascimento", "Email", "Latitude", "Longitude", "Nome", "PasswordHash", "PasswordSalt" },
                values: new object[,]
                {
                    { 1, "12345678911", null, null, null, null, "Felipe", null, null },
                    { 2, "12345678917", null, null, null, null, "Rebecca", null, null }
                });

            migrationBuilder.InsertData(
                table: "TB_PROFESSORES",
                columns: new[] { "Id", "Cpf", "DtaNascimento", "Email", "Latitude", "Longitude", "Nome", "PasswordHash", "PasswordSalt" },
                values: new object[,]
                {
                    { 1, "12345678910", null, null, null, null, "Luiz", null, null },
                    { 2, "22345678910", null, null, null, null, "Marion", null, null }
                });

            migrationBuilder.InsertData(
                table: "TB_MATERIAS",
                columns: new[] { "Id", "DataCriacao", "Descricao", "HorasDoCurso", "IdProfessor", "Nome", "StatusMateria" },
                values: new object[,]
                {
                    { 1, null, "Curso para lógica de C#", 36, 1, "C# e Suas Descobertas", 0 },
                    { 2, null, "Curso para lógica de Java", 88, 2, "Java e Suas Grandezas", 0 }
                });

            migrationBuilder.InsertData(
                table: "TB_MATRICULAS",
                columns: new[] { "AlunoId", "MateriaId", "DataMatricula" },
                values: new object[,]
                {
                    { 1, 1, null },
                    { 1, 2, null },
                    { 2, 1, null },
                    { 2, 2, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_MATERIAS_IdProfessor",
                table: "TB_MATERIAS",
                column: "IdProfessor");

            migrationBuilder.CreateIndex(
                name: "IX_TB_MATRICULAS_MateriaId",
                table: "TB_MATRICULAS",
                column: "MateriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_MATRICULAS");

            migrationBuilder.DropTable(
                name: "TB_ALUNOS");

            migrationBuilder.DropTable(
                name: "TB_MATERIAS");

            migrationBuilder.DropTable(
                name: "TB_PROFESSORES");
        }
    }
}
