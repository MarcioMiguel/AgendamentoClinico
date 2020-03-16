using Agendamento.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Agendamento.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
         : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Agenda> Agenda { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Estado> Estado { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Agenda>()
                        .HasOne(a => a.Medico)
                        .WithMany(b => b.Agendamentos)
                        .HasForeignKey(a => a.MedicoCodigo)
                        .HasForeignKey(a => a.PacienteCodigo);
        }
    }
}
