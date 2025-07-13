using FinanceSportApi.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace FinanceSportApi.Domain.Entityes
{
    public class Usuario : IdentityUser
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public TipoUsuario TipoUsuario { get; set; } = TipoUsuario.Usuario;
        public DateTime UltimoLogin { get; set; } = DateTime.Now;
        public ICollection<Investimento> Investimentos { get; set; }
        public ICollection<Transacao> Transacoes { get; set; }
        public Orcamento Orcamento { get; set; }
    }
}
