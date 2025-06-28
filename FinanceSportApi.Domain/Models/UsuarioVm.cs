using FinanceSportApi.Domain.Entityes;

namespace FinanceSportApi.Domain.Models
{
    public class UsuarioVm : BaseVm
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public ICollection<Investimento> Investimentos { get; set; }
        public ICollection<Transacao> Transacoes { get; set; }
        public Orcamento Orcamento { get; set; }
    }
}
