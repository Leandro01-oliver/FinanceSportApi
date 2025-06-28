using FinanceSportApi.Domain.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceSportApi.Infra.Data
{
    public class OrcamentoConfig : IEntityTypeConfiguration<Orcamento>
    {
        public void Configure(EntityTypeBuilder<Orcamento> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(x => x.Id).HasColumnName("OrcamentoId");
            builder.Property(x => x.ValorMensal).HasColumnType("nvarchar(MAX)");
            builder.Property(x => x.ValorReservadoInvestimentos).HasColumnType("nvarchar(MAX)");

            builder.HasOne(o => o.Usuario)
               .WithOne(u => u.Orcamento)
               .HasForeignKey<Orcamento>(o => o.UsuarioId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
