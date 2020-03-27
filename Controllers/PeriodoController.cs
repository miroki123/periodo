using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using periodo.DAL;
using periodo.Logic;
using periodo.Model;
using periodo.VO;

namespace periodo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PeriodoController : ControllerBase
    {
        private readonly PeriodoContext _context;
        private readonly SimulateLogic _logic;

        public PeriodoController(PeriodoContext context, SimulateLogic logic)
        {
            _context = context;
            _logic = logic;
        }

        [HttpPost("gerarperiodo")]
        public GenericResponse GerarPeriodo([FromBody] SimulateRequest body)
        {
            _logic.RemoverTudo();
            _logic.GerarDados(body);
            return new GenericResponse { Success = true };
        }

        [HttpGet("obteralunos")]
        public object ObterAlunos()
        {
            var list = _context.Aluno.Include(a => a.Notas)
                .Include(a => a.Turma)
                .ThenInclude(t => t.Materias);
            return list;
        }
    }
}