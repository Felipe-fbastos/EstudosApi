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

        public DbSet<Aluno> TB_ALUNO { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<Aluno>().ToTable("TB_ALUNO");

            modelBuilder.Entity<Aluno>().HasData(
                
            new Aluno(){Id=1,Nome="Felipe", Cpf="12345678911"},
            new Aluno(){Id=2,Nome="Rebecca", Cpf="12345678917"}
       
            );
        }
    }
}