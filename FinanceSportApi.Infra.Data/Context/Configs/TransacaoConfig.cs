using FinanceSportApi.Domain.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceSportApi.Infra.Data
{
    public class TransacaoConfig : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.HasKey(t => t.TransacaoId);

            builder.Property(t => t.TransacaoId)
                   .IsRequired();

            builder.Property(t => t.ProdutoId)
                   .IsRequired();

            builder.Property(t => t.InvestimentoId)
                   .IsRequired();

            builder.Property(t => t.TipoTransacao)
                   .IsRequired();

            builder.Property(t => t.TipoInstituicaoFinanceira)
                   .IsRequired();

            builder.Property(t => t.Data)
                   .IsRequired();

            builder.HasOne(t => t.Produto)
                   .WithMany()
                   .HasForeignKey(t => t.ProdutoId);

            builder.HasOne(t => t.Investimento)
                   .WithMany(i => i.Transacoes)
                   .HasForeignKey(t => t.InvestimentoId);
        }
    }
}
