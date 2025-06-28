using FinanceSportApi.Domain.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceSportApi.Infra.Data
{
    public class InvestimentoConfig : IEntityTypeConfiguration<Investimento>
    {
        public void Configure(EntityTypeBuilder<Investimento> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(x => x.Id).HasColumnName("InvestimentoId");
            builder.Property(x => x.TipoInvestimento).IsRequired();
            builder.Property(x => x.Nome).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Quantidade).IsRequired();
            builder.Property(x => x.PrecoUnitario).IsRequired();
            builder.Property(x => x.DataCompra);

            builder.HasOne(x => x.Usuario)
               .WithMany(u => u.Investimentos)
               .HasForeignKey(x => x.UsuarioId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}