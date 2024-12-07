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
    public class MatriculaController : ControllerBase
    {

      private readonly DataContext _context;
        
        public MatriculaController(DataContext context)
        {
            _context = context;
        }


        [HttpGet("GetAll")]

        public async Task<List<Matricula>> GetAll()
        {
            // return Ok(alunos);
            return await _context.TB_MATRICULAS.ToListAsync();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Materia>> GetSingle(int id)
        {

            //return Ok (alunos.FirstOrDefault(pe => pe.Id == id));

            return Ok(await _context.TB_MATERIAS.FindAsync(id));
        }


    }
}