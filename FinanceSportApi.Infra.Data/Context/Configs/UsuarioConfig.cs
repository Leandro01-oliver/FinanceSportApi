using FinanceSportApi.Domain.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceSportApi.Infra.Data
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(x => x.Id).HasColumnName("UsuarioId");

            builder.Property(p => p.Nome)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.Property(p => p.Telefone)
                   .IsRequired()
                   .HasMaxLength(16);

            builder.Property(u => u.Senha)
              .IsRequired()
              .HasMaxLength(100);

            builder.Property(u => u.Telefone)
                   .HasMaxLength(20);

            builder.HasMany(u => u.Investimentos)
                   .WithOne(i => i.Usuario)
                   .HasForeignKey(i => i.UsuarioId);

            builder.HasMany(u => u.Transacoes)
                   .WithOne(t => t.Usuario)
                   .HasForeignKey(t => t.UsuarioId);

            builder.HasOne(u => u.Orcamento)
                   .WithOne(o => o.Usuario)
                   .HasForeignKey<Orcamento>(o => o.UsuarioId);
        }
    }
}
