using FinanceSportApi.Domain.Enums;
using FinanceSportApi.Domain.Models;

namespace FinanceSportApi.Domain.Models
{
    public class InvestimentoVm
    {
        public string InvestimentoId { get; set; }
        public TipoProdutoInvestimento TipoProdutoInvestimento { get; set; }
        public TipoAcaoInvestimento TipoAcaoInvestimento { get; set; }
        public double? TaxaJuros { get; set; }
        public string? OutrosTipoProdutoInvestimento { get; set; }
        public string? OutrosTipoAcaoInvestimento { get; set; }
        public List<TransacaoVm> Transacoes { get; set; } = new();
    }
}