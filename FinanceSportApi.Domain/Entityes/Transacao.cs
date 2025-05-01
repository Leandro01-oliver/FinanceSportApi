using FinanceSportApi.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceSportApi.Domain.Entityes
{
    public class Transacao
    {
        [Key]
        public string TransacaoId { get; set; }

        [Required]
        public string ProdutoId { get; set; }
        public string InvestimentoId { get; set; }

        [Required]
        public TipoTransacao TipoTransacao { get; set; }

        [Required]
        public TipoInstituicaoFinanceira TipoInstituicaoFinanceira { get; set; }

        public string? OutrosTipoTransacao { get; set; }
        public string? OutrosTipoInstituicaoFinanceira { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [ForeignKey("ProdutoId")]
        public Produto Produto { get; set; }
        [ForeignKey("InvestimentoId")]
        public Investimento Investimento { get; set; }
    }

}