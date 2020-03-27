using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace periodo.Model
{
    public class Nota
    {
        public int AlunoID { get; set; }
        public int MateriaID { get; set; }
        public int TurmaID { get; set; }
        public double Nota1 { get; set; }
        public double Nota2 { get; set; }
        public double Nota3 { get; set; }
        public double Nota4 { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual Materia Materia { get; set; }
        public virtual Turma Turma { get; set; }

        public bool IsAprovado
        {
            get {
                double media = (Nota1 * Materia.Peso1
                    + Nota2 * Materia.Peso2
                    + Nota3 * Materia.Peso3) 
                    / (Materia.Peso1 + Materia.Peso2 + Materia.Peso3);

                if (media >= 6d)
                    return true;
                else if (media <= 4d)
                    return false;
                else
                    return (media + Nota4) / 2d >= 5d;
            }
        }
    }
}
