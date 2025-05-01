using FinanceSportApi.Domain.Enums;
using FinanceSportApi.Domain.Models;

namespace FinanceSportApi.Domain.Models
{
    public class TransacaoVm
    {
        public string TransacaoId { get; set; }
        public string ProdutoId { get; set; }
        public TipoTransacao TipoTransacao { get; set; }
        public TipoInstituicaoFinanceira TipoInstituicaoFinanceira { get; set; }
        public string? OutrosTipoTransacao { get; set; }
        public string? OutrosTipoInstituicaoFinanceira { get; set; }
        public DateTime Data { get; set; }
        public ProdutoVm Produto { get; set; }
    }
}