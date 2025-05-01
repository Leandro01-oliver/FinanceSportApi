using System.ComponentModel.DataAnnotations;

namespace FinanceSportApi.Domain.Entityes
{
    public class Produto
    {
        [Key]
        public string ProdutoId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public string Valor { get; set; }

        [Required]
        public long Quantidade { get; set; }
    }
}
