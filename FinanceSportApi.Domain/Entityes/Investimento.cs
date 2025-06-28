using FinanceSportApi.Domain.Enums;

namespace FinanceSportApi.Domain.Entityes
{
    public class Investimento : Base
    {
        public TipoInvestimento TipoInvestimento { get; set; } 
        public string Nome { get; set; } 
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public DateTime DataCompra { get; set; } = DateTime.Now;
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}