namespace FinanceSportApi.Domain.Models
{
    public class OrcamentoVm : BaseVm
    {
        public string ValorMensal { get; set; }
        public string ValorReservadoInvestimentos { get; set; }
        public string UsuarioId { get; set; }
        public UsuarioVm Usuario { get; set; }
    }
}