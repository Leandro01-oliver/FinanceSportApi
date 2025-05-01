using FinanceSportApi.Domain.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceSportApi.Infra.Data
{
    public class InvestimentoConfig : IEntityTypeConfiguration<Investimento>
    {
        public void Configure(EntityTypeBuilder<Investimento> builder)
        {
            builder.HasKey(i => i.InvestimentoId);

            builder.Property(i => i.InvestimentoId)
                   .IsRequired();

            builder.Property(i => i.TipoProdutoInvestimento)
                   .IsRequired(); 

            builder.Property(i => i.TipoAcaoInvestimento)
                   .IsRequired();

            builder.Property(i => i.TaxaJuros);

            builder.Property(i => i.OutrosTipoProdutoInvestimento)
                   .HasMaxLength(255); 

            builder.Property(i => i.OutrosTipoAcaoInvestimento)
                   .HasMaxLength(255);

            builder.HasMany(i => i.Transacoes)
                   .WithOne(x => x.Investimento) 
                   .HasForeignKey(x => x.TransacaoId) 
                   .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}