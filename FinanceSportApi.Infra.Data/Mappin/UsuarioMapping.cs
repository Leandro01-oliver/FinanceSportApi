using FinanceSportApi.Domain.Entityes;
using FinanceSportApi.Domain.Models;

namespace FinanceSportApi.Infraestruture.Data.Mapping
{
    public static class UsuarioMapping
    {
        public static UsuarioVm ToViewModel(this Usuario usuario)
        {
            if (usuario == null) return null;

            return new UsuarioVm
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Telefone = usuario.Telefone,
                Email = usuario.Email,
                Senha = usuario.Senha,
                Investimentos = usuario.Investimentos,
                Transacoes = usuario.Transacoes,
                Orcamento = usuario.Orcamento
            };
        }

        public static Usuario ToEntity(this UsuarioVm usuarioVm)
        {
            if (usuarioVm == null) return null;

            return new Usuario
            {
                Id = usuarioVm.Id,
                Nome = usuarioVm.Nome,
                Telefone = usuarioVm.Telefone,
                Email = usuarioVm.Email,
                Senha = usuarioVm.Senha,
                Investimentos = usuarioVm.Investimentos,
                Transacoes = usuarioVm.Transacoes,
                Orcamento = usuarioVm.Orcamento
            };
        }
    }
}
