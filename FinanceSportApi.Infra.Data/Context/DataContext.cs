using FinanceSportApi.Domain.Entityes;
using Microsoft.EntityFrameworkCore;

namespace FinanceSportApi.Infra.Data.Context
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<Investimento>? Investimentos { get; set; }
        public DbSet<Produto>? Produtos { get; set; }
        public DbSet<Transacao>? Transacaos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InvestimentoConfig());
            modelBuilder.ApplyConfiguration(new ProdutoConfig());
            modelBuilder.ApplyConfiguration(new TransacaoConfig());
        }
    }
}
