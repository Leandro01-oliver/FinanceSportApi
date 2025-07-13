using FinanceSportApi.Domain.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceSportApi.Infra.Data
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            // O Identity já gerencia a chave primária (Id)
            // Não precisamos configurar a chave novamente

            builder.Property(p => p.Nome)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.Property(p => p.Telefone)
                   .IsRequired()
                   .HasMaxLength(16);

            // O Identity já gerencia Email, UserName, etc.
            // Removemos a configuração de Senha pois o Identity usa PasswordHash

            builder.Property(u => u.TipoUsuario)
                   .IsRequired()
                   .HasConversion<string>();

            builder.Property(u => u.UltimoLogin)
                   .IsRequired();

            builder.HasMany(u => u.Investimentos)
                   .WithOne(i => i.Usuario)
                   .HasForeignKey(i => i.UsuarioId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Transacoes)
                   .WithOne(t => t.Usuario)
                   .HasForeignKey(t => t.UsuarioId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(u => u.Orcamento)
                   .WithOne(o => o.Usuario)
                   .HasForeignKey<Orcamento>(o => o.UsuarioId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
