﻿// <auto-generated />
using System;
using EstudosApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EstudosApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241112184620_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EstudosApi.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DtaNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("TB_ALUNOS", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cpf = "12345678911",
                            Nome = "Felipe"
                        },
                        new
                        {
                            Id = 2,
                            Cpf = "12345678917",
                            Nome = "Rebecca"
                        });
                });

            modelBuilder.Entity("EstudosApi.Models.Materia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HorasDoCurso")
                        .HasColumnType("int");

                    b.Property<int>("IdProfessor")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusMateria")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdProfessor");

                    b.ToTable("TB_MATERIAS", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Curso para lógica de C#",
                            HorasDoCurso = 36,
                            IdProfessor = 1,
                            Nome = "C# e Suas Descobertas",
                            StatusMateria = 0
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "Curso para lógica de Java",
                            HorasDoCurso = 88,
                            IdProfessor = 2,
                            Nome = "Java e Suas Grandezas",
                            StatusMateria = 0
                        });
                });

            modelBuilder.Entity("EstudosApi.Models.Matricula", b =>
                {
                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int>("MateriaId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataMatricula")
                        .HasColumnType("datetime2");

                    b.HasKey("AlunoId", "MateriaId");

                    b.HasIndex("MateriaId");

                    b.ToTable("TB_MATRICULAS", (string)null);

                    b.HasData(
                        new
                        {
                            AlunoId = 1,
                            MateriaId = 1
                        },
                        new
                        {
                            AlunoId = 2,
                            MateriaId = 1
                        },
                        new
                        {
                            AlunoId = 1,
                            MateriaId = 2
                        },
                        new
                        {
                            AlunoId = 2,
                            MateriaId = 2
                        });
                });

            modelBuilder.Entity("EstudosApi.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DtaNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("TB_PROFESSORES", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cpf = "12345678910",
                            Nome = "Luiz"
                        },
                        new
                        {
                            Id = 2,
                            Cpf = "22345678910",
                            Nome = "Marion"
                        });
                });

            modelBuilder.Entity("EstudosApi.Models.Materia", b =>
                {
                    b.HasOne("EstudosApi.Models.Professor", "Professor")
                        .WithMany("Materias")
                        .HasForeignKey("IdProfessor");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("EstudosApi.Models.Matricula", b =>
                {
                    b.HasOne("EstudosApi.Models.Aluno", "Aluno")
                        .WithMany("Matricula")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EstudosApi.Models.Materia", "Materia")
                        .WithMany("Matricula")
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Materia");
                });

            modelBuilder.Entity("EstudosApi.Models.Aluno", b =>
                {
                    b.Navigation("Matricula");
                });

            modelBuilder.Entity("EstudosApi.Models.Materia", b =>
                {
                    b.Navigation("Matricula");
                });

            modelBuilder.Entity("EstudosApi.Models.Professor", b =>
                {
                    b.Navigation("Materias");
                });
#pragma warning restore 612, 618
        }
    }
}
