using FinanceSportApi.Domain.Enums;

namespace FinanceSportApi.Domain.Models
{
    public class InvestimentoVm : BaseVm
    {
        public TipoInvestimento TipoInvestimento { get; set; } 
        public string Nome { get; set; } 
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public DateTime DataCompra { get; set; }
        public Guid UsuarioId { get; set; }
        public UsuarioVm Usuario { get; set; }
    }
}