using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstudosApi.Data;
using EstudosApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EstudosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MateriaController : ControllerBase
    {
        private readonly DataContext _context;

        public MateriaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<List<Materia>> GetAll()
        {

            // return Ok(alunos);
            return await _context.TB_MATERIAS.ToListAsync();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Materia>> GetSingle(int id)
        {
            //return Ok (alunos.FirstOrDefault(pe => pe.Id == id));

            return Ok(await _context.TB_MATERIAS.FindAsync(id));
        }


        private async Task<bool> MateriaExistente(string nmMateria)
        {

            if (await _context.TB_MATERIAS.AnyAsync(x => x.Nome.ToLower() == nmMateria.ToLower()))
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        [HttpPost("SingUp")]

        public async Task<IActionResult> MateriaCadastro(Materia materia)
        {
            try
            {

                if (await MateriaExistente(materia.Nome))
                    throw new System.Exception("Esta matéria já existe");

                return Ok(materia.Id);

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + ex.InnerException);
            }
        }
    }
}