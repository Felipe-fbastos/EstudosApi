using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstudosApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstudosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunosController : ControllerBase
    {
        private static List<Aluno> alunos = new List<Aluno>(){
            new Aluno(){Id=1,Nome="Felipe", Cpf="12345678911"},
            new Aluno(){Id=2,Nome="Rebecca", Cpf="12345678917"}
        };

        [HttpGet("GetAll")]

        public IActionResult Get(){

            return Ok(alunos);
        }
    }
}