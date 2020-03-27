using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace periodo.Model
{
    public class Aluno
    {
        public int ID { get; set; }
        public int TurmaID { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Turma Turma { get; set; }
        public virtual ICollection<Nota> Notas { get; set; }
        public bool IsAprovado
        {
            get
            {
                float aprovados = 0f;
                foreach (Nota n in Notas)
                {
                    aprovados += (n.IsAprovado ? 1f : 0f);
                }
                return aprovados / (float)Notas.Count >= 0.6f;
            }
        }
    }
}
