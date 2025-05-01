using FinanceSportApi.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace FinanceSportApi.Domain.Entityes
{
    public class Investimento
    {
        [Key]
        public string InvestimentoId { get; set; }

        [Required]
        public TipoProdutoInvestimento TipoProdutoInvestimento { get; set; }

        [Required]
        public TipoAcaoInvestimento TipoAcaoInvestimento { get; set; }

        public double? TaxaJuros { get; set; }

        public string? OutrosTipoProdutoInvestimento { get; set; }

        public string? OutrosTipoAcaoInvestimento { get; set; }

        public List<Transacao> Transacoes { get; set; } = new();
    }

}