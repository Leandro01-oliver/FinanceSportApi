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
                InvestimentoId = investimento.InvestimentoId,
                TipoProdutoInvestimento = investimento.TipoProdutoInvestimento,
                TipoAcaoInvestimento = investimento.TipoAcaoInvestimento,
                TaxaJuros = investimento.TaxaJuros,
                OutrosTipoProdutoInvestimento = investimento.OutrosTipoProdutoInvestimento,
                OutrosTipoAcaoInvestimento = investimento.OutrosTipoAcaoInvestimento,
                Transacoes = investimento.Transacoes.Select(t => t.ToViewModel()).ToList()
            };
        }

        public static Investimento ToEntity(this InvestimentoVm investimentoViewModel)
        {
            if (investimentoViewModel == null) return null;

            return new Investimento
            {
                InvestimentoId = investimentoViewModel.InvestimentoId,
                TipoProdutoInvestimento = investimentoViewModel.TipoProdutoInvestimento,
                TipoAcaoInvestimento = investimentoViewModel.TipoAcaoInvestimento,
                TaxaJuros = investimentoViewModel.TaxaJuros,
                OutrosTipoProdutoInvestimento = investimentoViewModel.OutrosTipoProdutoInvestimento,
                OutrosTipoAcaoInvestimento = investimentoViewModel.OutrosTipoAcaoInvestimento,
                Transacoes = investimentoViewModel.Transacoes.Select(t => t.ToEntity()).ToList()
            };
        }
    }
}
