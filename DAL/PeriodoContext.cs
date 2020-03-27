using Microsoft.EntityFrameworkCore;
using periodo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace periodo.DAL
{
    public class PeriodoContext : DbContext
    {
        public PeriodoContext(DbContextOptions<PeriodoContext> context) : base(context)
        {

        }

        public DbSet<Turma> Turma { get; set; }
        public DbSet<Materia> Materia { get; set; }
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Nota> Nota { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TURMA

            modelBuilder.Entity<Turma>()
                .HasKey(t => t.ID);

            modelBuilder.Entity<Turma>()
                .HasMany<Aluno>(t => t.Alunos)
                .WithOne(a => a.Turma);

            modelBuilder.Entity<Turma>()
                .HasMany<Materia>(t => t.Materias)
                .WithOne(m => m.Turma);

            // MATERIA

            modelBuilder.Entity<Materia>()
                .HasKey(m => m.ID);

            modelBuilder.Entity<Materia>()
                .HasOne<Turma>(m => m.Turma)
                .WithMany(t => t.Materias);

            // NOTA

            modelBuilder.Entity<Nota>()
                .HasKey(n => new { n.AlunoID, n.MateriaID, n.TurmaID });

            modelBuilder.Entity<Nota>()
                .HasOne<Aluno>(n => n.Aluno)
                .WithMany(a => a.Notas);

            modelBuilder.Entity<Nota>()
                .HasOne<Materia>(n => n.Materia);

            modelBuilder.Entity<Nota>()
                .HasOne<Turma>(n => n.Turma);

            // ALUNO

            modelBuilder.Entity<Aluno>()
                .HasKey(a => a.ID);

            modelBuilder.Entity<Aluno>()
                .HasMany<Nota>(a => a.Notas)
                .WithOne(n => n.Aluno);

            modelBuilder.Entity<Aluno>()
                .HasOne<Turma>(a => a.Turma)
                .WithMany(t => t.Alunos);

        }
        
    }
}
