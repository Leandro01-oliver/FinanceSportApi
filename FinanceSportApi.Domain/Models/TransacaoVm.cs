using FinanceSportApi.Domain.Enums;

namespace FinanceSportApi.Domain.Models
{
    public class TransacaoVm : BaseVm
    {
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public TipoTransacao TipoTransacao { get; set; } 
        public string Descricao { get; set; }

        public string UsuarioId { get; set; }
        public UsuarioVm Usuario { get; set; }
    }
}