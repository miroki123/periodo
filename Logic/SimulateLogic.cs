using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using periodo.DAL;
using periodo.Infrastructure;
using periodo.Model;
using periodo.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace periodo.Logic
{
    public class SimulateLogic
    {
        private readonly PeriodoContext _context;
        private readonly FileManager _fileManager;
        private List<Aluno> _alunos;

        public SimulateLogic(PeriodoContext context, FileManager fileManager)
        {
            _context = context;
            _fileManager = fileManager;
            _alunos = ObterAlunosMock();
        }

        List<Aluno> ObterAlunosMock()
        {
            string alunos = _fileManager.FileToString("mock.json");
            return JsonConvert.DeserializeObject<List<Aluno>>(alunos);
        }

        public void RemoverTudo()
        {
            _context.Nota.RemoveRange(_context.Nota);
            _context.Materia.RemoveRange(_context.Materia);
            _context.Aluno.RemoveRange(_context.Aluno);
            _context.Turma.RemoveRange(_context.Turma);
            _context.SaveChanges();
        }

        public void GerarDados(SimulateRequest request)
        {
            GerarTurmas(request);
            _context.SaveChanges();
        }

        void GerarNotas()
        {
            Random r = new Random();
            foreach (Aluno a in _context.Aluno)
            {
                foreach (Materia m in _context.Materia.Where(mat => mat.TurmaID == a.TurmaID))
                {
                    double[] notas = new double[4];
                    for (int i = 0; i < 4; i++)
                    {
                        notas[i] = Math.Round(r.Next(0, 100) * 0.1d, 1);
                    }

                    Nota nota = new Nota
                    {
                        AlunoID = a.ID,
                        MateriaID = m.ID,
                        TurmaID = a.TurmaID,
                        Nota1 = notas[0],
                        Nota2 = notas[1],
                        Nota3 = notas[2],
                        Materia = m
                    };

                    if (!nota.IsAprovado)
                    {
                        nota.Nota4 = notas[3];
                    }

                    _context.Nota.Add(nota);
                }
            }
        }

        void GerarMaterias(List<Materia> materias, int turma)
        {
            int id = _context.Materia.Any() ? _context.Materia.Max(a => a.ID) + 1 : 1;
            for (int i = 0; i < materias.Count; i++)
            {
                Materia m = materias[i];
                m.ID = id + i;
                m.TurmaID = turma;
                _context.Materia.Add(m);
            }
        }

        void GerarAlunos(int alunos, int turma)
        {
            int id = _context.Aluno.Any() ? _context.Aluno.Max(a => a.ID) + 1 : 1;
            Random r = new Random();
            for (int i = 0; i < alunos; i++)
            {
                Aluno aluno = _alunos[r.Next(0, _alunos.Count - 1)];
                aluno.ID = id + i;
                aluno.TurmaID = turma;
                _context.Aluno.Add(aluno);
            }
        }

        void GerarTurmas(SimulateRequest request)
        {
            int id = _context.Turma.Any() ? _context.Turma.Max(t => t.ID) + 1 : 1;
            for (int i = 0; i < request.Turmas; i++)
            {
                _context.Turma.Add(new Model.Turma
                {
                    ID = id + i,
                    Nome = "Turma " + (id + i),
                    DataInicio = new DateTime(2020, 01, 01),
                    DataFim = new DateTime(2020, 06, 30)
                });

                GerarAlunos(request.Alunos, id + i);
                GerarMaterias(request.Materias, id + i);
                _context.SaveChanges();
            }
            GerarNotas();
        }
    }
}
