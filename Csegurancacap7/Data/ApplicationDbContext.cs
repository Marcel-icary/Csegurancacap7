using Microsoft.EntityFrameworkCore;
using Csegurancacap7.Models;

namespace Csegurancacap7.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Construtor do contexto que recebe as opções de configuração
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets que representam as tabelas do banco de dados
        public DbSet<User> Users { get; set; } // Tabela de usuários
        public DbSet<Zone> Zones { get; set; } // Tabela de zonas
        public DbSet<SO> SOs { get; set; } // Tabela de solicitações de ocorrências
        public DbSet<Team> Teams { get; set; } // Tabela de equipes
        public DbSet<Ocorrencia> Ocorrencias { get; set; } // Tabela de ocorrências
        public DbSet<Auditoria> Auditorias { get; set; } // Tabela de auditorias

        // Método para configurar o modelo de dados
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Chama o método base para aplicar as configurações padrão
            base.OnModelCreating(modelBuilder);
        }
    }
}
    