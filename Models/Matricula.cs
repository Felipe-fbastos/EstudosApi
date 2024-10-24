using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstudosApi.Models
{
    public class Matricula
    {
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }   
        public int MateriaId { get; set; } 
        public Materia Materia { get; set; } 

        public DateTime DataMatricula { get; set; } 
    }
}