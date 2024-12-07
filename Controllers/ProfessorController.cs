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
    public class ProfessorController : ControllerBase
    {
        private readonly DataContext _context;

        public ProfessorController(DataContext context)
        {
            _context = context;
        }


        [HttpGet("GetAll")]
        public async Task<List<Professor>> GetAll()
        {

            // return Ok(alunos);
            return await _context.TB_PROFESSORES.ToListAsync();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Professor>> GetSingle(int id)
        {

            //return Ok (alunos.FirstOrDefault(pe => pe.Id == id));

            return Ok(await _context.TB_PROFESSORES.FindAsync(id));
        }


        private async Task<bool> ProfessorExistente(string nmProfessor)
        {

            if (await _context.TB_PROFESSORES.AnyAsync(x => x.Nome.ToLower() == nmProfessor.ToLower()))
            {
                return true;

            }
            else
            {
                return false;
            }
        }


        [HttpPost("SignUp")]

        public async Task<IActionResult> ProfessorCadastro(Professor professor)
        {

            try
            {

                if (await ProfessorExistente(professor.Nome))
                    throw new System.Exception("Nome de usuário já existe");

                Criptografia.CriarPasswordHash(professor.PassowordString, out byte[] hash, out byte[] salt);
                professor.PassowordString = string.Empty;
                professor.PasswordHash = hash;
                professor.PasswordSalt = salt;
                //Adiciona o usuário no banco
                await _context.TB_PROFESSORES.AddAsync(professor);
                await _context.SaveChangesAsync();

                return Ok(professor.Id);




            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + ex.InnerException);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAluno(Professor credenciais)
        {
            try
            {
                Professor professor = await _context.TB_PROFESSORES
                          .FirstOrDefaultAsync(Busca => Busca.Nome.ToLower().Equals(credenciais.Nome.ToLower()));

                if (professor == null)
                {
                    throw new System.Exception("Usuário não encontrado.");
                }
                else if (!Criptografia.VerificarPasswordHash(credenciais.PassowordString, professor.PasswordHash, professor.PasswordSalt))
                {
                    throw new System.Exception("Senha incorreta.");
                }
                else
                {

                    professor.DtaAcesso = DateTime.Now;

                    await _context.SaveChangesAsync();

                    return Ok($"Aluno encontrado {professor}");
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }

        }
    }
}