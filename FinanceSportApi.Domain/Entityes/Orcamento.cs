namespace FinanceSportApi.Domain.Entityes
{
    public class Orcamento : Base
    {
        public string ValorMensal { get; set; }
        public string ValorReservadoInvestimentos { get; set; }
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}