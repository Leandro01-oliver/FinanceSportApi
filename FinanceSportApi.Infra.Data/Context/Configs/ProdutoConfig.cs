using FinanceSportApi.Domain.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceSportApi.Infra.Data
{
    public class ProdutoConfig : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.ProdutoId);

            builder.Property(p => p.ProdutoId).IsRequired();

            builder.Property(p => p.Nome)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.Descricao)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(p => p.Valor)
                   .IsRequired();

            builder.Property(p => p.Quantidade)
                   .IsRequired();
        }
    }
}
