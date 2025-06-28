using FinanceSportApi.Domain.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceSportApi.Infra.Data
{
    public class TransacaoConfig : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(x => x.Id).HasColumnName("TransacaoId");
            builder.Property(x => x.Valor).HasColumnType("nvarchar(MAX)").IsRequired();
            builder.Property(x => x.TipoTransacao).IsRequired();
            builder.Property(x => x.Descricao).HasMaxLength(250).IsRequired();
            builder.Property(t => t.Valor).IsRequired();

            builder.Property(t => t.Data)
                   .IsRequired();

            builder.HasOne(t => t.Usuario)
                   .WithMany(u => u.Transacoes)
                   .HasForeignKey(t => t.UsuarioId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
