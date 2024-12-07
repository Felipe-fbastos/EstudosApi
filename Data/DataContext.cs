using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstudosApi.Models;
using Microsoft.EntityFrameworkCore;


namespace EstudosApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Aluno> TB_ALUNOS { get; set; }
        public DbSet<Matricula> TB_MATRICULAS { get; set; }
        public DbSet<Materia> TB_MATERIAS { get; set; }
        public DbSet<Professor> TB_PROFESSORES { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().ToTable("TB_ALUNOS");
            modelBuilder.Entity<Matricula>().ToTable("TB_MATRICULAS");
            modelBuilder.Entity<Materia>().ToTable("TB_MATERIAS");
            modelBuilder.Entity<Professor>().ToTable("TB_PROFESSORES");




            modelBuilder.Entity<Aluno>().HasData(

            new Aluno() { Id = 1, Nome = "Felipe", Cpf = "12345678911",},
            new Aluno() { Id = 2, Nome = "Rebecca", Cpf = "12345678917" }

            );

            modelBuilder.Entity<Materia>().HasData(
                
                    new Materia() { Id=1, Nome="C# e Suas Descobertas", HorasDoCurso = 36, Descricao="Curso para lógica de C#", IdProfessor = 1, StatusMateria=Models.Enuns.StatusMateria.Ativa, },
                    
                    new Materia() { Id=2, Nome="Java e Suas Grandezas", HorasDoCurso = 88, Descricao="Curso para lógica de Java", IdProfessor = 2, StatusMateria=Models.Enuns.StatusMateria.Ativa, }
                
            );


            modelBuilder.Entity<Professor>().HasData(

                new Professor() {Id = 1, Nome="Luiz", Cpf="12345678910" },
                new Professor() {Id = 2, Nome="Marion", Cpf="22345678910" }
            );

            modelBuilder.Entity<Matricula>().HasData(

                new Matricula() {AlunoId = 1, MateriaId=1},
                new Matricula() {AlunoId = 2, MateriaId=1},
                new Matricula() {AlunoId = 1, MateriaId=2},
                new Matricula() {AlunoId = 2, MateriaId=2}

            );



            modelBuilder.Entity<Materia>()
            .HasOne(pro => pro.Professor)
            .WithMany(ma => ma.Materias)
            .HasForeignKey(fkPro => fkPro.IdProfessor)
            .IsRequired(false);

            modelBuilder.Entity<Matricula>()
            .HasKey(al => new {al.AlunoId, al.MateriaId});
            
        }

        internal async Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }



        /*public DataContext(DbContextOptions<DataContext> opitions) : base(opitions)
        {

        }

        public DbSet<Livro> TB_Livro { get; set; }
        public DbSet<Autor> TB_Autor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Livro>().ToTable("TB_Livro");
            modelBuilder.Entity<Autor>().ToTable("TB_Autor");

            modelBuilder.Entity<Autor>()
            .HasMany(l => l.Livros)
            .WithOne(a => a.Autor)
            .HasForeignKey(idAu => idAu.IdAutor)
            .IsRequired(false);

            modelBuilder.Entity<Autor>().HasData(
            new Autor { Id = 1, Nome = "J.K. Rowling", Cpf = "12345678900", Longitude = 0, Latitude = 0, DataNascimento = new DateTime(1965, 7, 31) }
            );


            modelBuilder.Entity<Livro>().HasData(

                new Livro() { Id = 1, Editora = "PedroBala", IdAutor = 1, Nome = "Harry Potter", Preco = 50, QtdPaginas = 365 }
            );
*/
    }
}