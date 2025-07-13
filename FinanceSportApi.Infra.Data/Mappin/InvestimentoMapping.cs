using FinanceSportApi.Domain.Entityes;
using FinanceSportApi.Domain.Models;

namespace FinanceSportApi.Infraestruture.Data.Mapping
{
    public static class InvestimentoMapping
    {
        public static InvestimentoVm ToViewModel(this Investimento investimento)
        {
            if (investimento == null) return null;

            return new InvestimentoVm
            {
                Id = investimento.Id,
                TipoInvestimento = investimento.TipoInvestimento,
                Nome = investimento.Nome,
                Quantidade = investimento.Quantidade,
                PrecoUnitario = investimento.PrecoUnitario,
                DataCompra = investimento.DataCompra,
                UsuarioId = investimento.UsuarioId,
                Usuario = new UsuarioVm
                {
                    Id = Guid.Parse(investimento.Usuario.Id),
                    Nome = investimento.Usuario.Nome
                }
            };
        }

        public static Investimento ToEntity(this InvestimentoVm investimentoVm)
        {
            if (investimentoVm == null) return null;

            return new Investimento
            {
                Id = investimentoVm.Id,
                TipoInvestimento = investimentoVm.TipoInvestimento,
                Nome = investimentoVm.Nome,
                Quantidade = investimentoVm.Quantidade,
                PrecoUnitario = investimentoVm.PrecoUnitario,
                DataCompra = investimentoVm.DataCompra,
                UsuarioId = investimentoVm.UsuarioId
            };
        }
    }
}
