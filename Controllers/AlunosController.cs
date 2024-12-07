using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstudosApi.Data;
using EstudosApi.Models;
using EstudosApi.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EstudosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunosController : ControllerBase
    {
             
        private readonly DataContext _context;

        public AlunosController(DataContext context){
            _context = context;
        }
        

        [HttpGet("GetAll")]

        public async Task<List<Aluno>> GetAll (){

           // return Ok(alunos);
            return await _context.TB_ALUNOS.ToListAsync();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>>  GetSingle(int id){

            //return Ok (alunos.FirstOrDefault(pe => pe.Id == id));

            return Ok (await _context.TB_ALUNOS.FindAsync(id));
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

        public async Task<IActionResult> Aluno(Aluno aluno){

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
                return BadRequest(ex.Message + ex.InnerException);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAluno(Aluno credenciais)
        {
            try
            {
                Aluno aluno = await _context.TB_ALUNOS
                   .FirstOrDefaultAsync(Busca => Busca.Nome.ToLower().Equals(credenciais.Nome.ToLower()));

                if (aluno == null)
                {
                    throw new System.Exception("Usuário não encontrado.");
                }
                else if (!Criptografia.VerificarPasswordHash(credenciais.PassowordString, aluno.PasswordHash, aluno.PasswordSalt))
                {
                    throw new System.Exception("Senha incorreta.");
                }
                else
                {

                    aluno.DtaAcesso = DateTime.Now;

                    await _context.SaveChangesAsync();

                    return Ok($"Aluno encontrado {aluno}");
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }

        }
    }
}