using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace periodo.Model
{
    public class Turma
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public virtual ICollection<Aluno> Alunos { get; set; }
        public virtual ICollection<Materia> Materias { get; set; }
    }
}
