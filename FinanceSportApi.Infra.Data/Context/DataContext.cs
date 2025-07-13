using FinanceSportApi.Domain.Entityes;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinanceSportApi.Infra.Data.Context
{
    public class DataContext(DbContextOptions<DataContext> options) : IdentityDbContext<Usuario>(options)
    {
        public DbSet<Investimento>? Investimentos { get; set; }
        public DbSet<Orcamento>? Orcamentos { get; set; }
        public DbSet<Transacao>? Transacaos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new InvestimentoConfig());
            modelBuilder.ApplyConfiguration(new OrcamentoConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new TransacaoConfig());
        }
    }
}
