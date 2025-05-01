namespace FinanceSportApi.Domain.Models
{
    public class ProdutoVm
    {
        public string ProdutoId { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Valor { get; set; }

        public long Quantidade { get; set; }
    }
}