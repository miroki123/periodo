using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace periodo.Model
{
    public class Materia
    {
        public int ID { get; set; }
        public int TurmaID { get; set; }
        public string Nome { get; set; }
        public double Peso1 { get; set; }
        public double Peso2 { get; set; }
        public double Peso3 { get; set; }
        public virtual Turma Turma { get; set; }
    }
}
