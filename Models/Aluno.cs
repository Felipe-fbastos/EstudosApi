using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EstudosApi.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DtaNascimento { get; set; }
       // public List<Matricula> Matricula { get; set; } = new List<Matricula>();
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? Email { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }

        [NotMapped]
        public string PassowordString { get; set; }




    }
}