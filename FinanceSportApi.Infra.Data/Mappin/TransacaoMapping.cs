using FinanceSportApi.Domain.Entityes;
using FinanceSportApi.Domain.Models;

namespace FinanceSportApi.Infraestruture.Data.Mapping
{
    public static class TransacaoMapping
    {
        public static TransacaoVm ToViewModel(this Transacao transacao)
        {
            if (transacao == null) return null;

            return new TransacaoVm
            {
                TransacaoId = transacao.TransacaoId,
                ProdutoId = transacao.ProdutoId,
                TipoTransacao = transacao.TipoTransacao,
                TipoInstituicaoFinanceira = transacao.TipoInstituicaoFinanceira,
                OutrosTipoTransacao = transacao.OutrosTipoTransacao,
                OutrosTipoInstituicaoFinanceira = transacao.OutrosTipoInstituicaoFinanceira,
                Data = transacao.Data
            };
        }

        public static Transacao ToEntity(this TransacaoVm transacaoViewModel)
        {
            if (transacaoViewModel == null) return null;

            return new Transacao
            {
                TransacaoId = transacaoViewModel.TransacaoId,
                ProdutoId = transacaoViewModel.ProdutoId,
                TipoTransacao = transacaoViewModel.TipoTransacao,
                TipoInstituicaoFinanceira = transacaoViewModel.TipoInstituicaoFinanceira,
                OutrosTipoTransacao = transacaoViewModel.OutrosTipoTransacao,
                OutrosTipoInstituicaoFinanceira = transacaoViewModel.OutrosTipoInstituicaoFinanceira,
                Data = transacaoViewModel.Data
            };
        }
    }
}
