using periodo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace periodo.VO
{
    public class SimulateRequest
    {
        public int Turmas { get; set; }
        public int Alunos { get; set; }
        public List<Materia> Materias { get; set; }
    }
}
