using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstudosApi.Data;
using EstudosApi.Models;
using EstudosApi.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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

        
        private readonly DataContext _context;

        public AlunosController(DataContext context){
            _context = context;
        }
        

        [HttpGet("GetAll")]

        public IActionResult GetAll(){

            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public IActionResult  GetSingle(int id){

            return Ok (alunos.FirstOrDefault(pe => pe.Id == id));
        }


        private async Task<bool> AlunosExistente(string NomeAluno){

            if(await _context.TB_ALUNOS.AnyAsync(x => x.Nome.ToLower() == NomeAluno.ToLower())){
                return true;

            }
            else{
                return false;
            }
        }





        [HttpPost("SignUp")]

        public async Task<IActionResult> LoginAluno(Aluno aluno){

            try{

                if(await AlunosExistente(aluno.Nome))
                throw new System.Exception("Nome de usuário já existe");  

                Criptografia.CriarPasswordHash(aluno.PassowordString, out byte[] hash, out byte[] salt);
                aluno.PassowordString = string.Empty;
                aluno.PasswordHash = hash;
                aluno.PasswordSalt = salt;
                //Adiciona o usuário no banco
                await _context.TB_ALUNOS.AddAsync(aluno);
                await _context.SaveChangesAsync();

                return Ok(aluno.Id);




            }
            catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
        }
    }
}