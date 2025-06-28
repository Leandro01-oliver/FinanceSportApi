using FinanceSportApi.Domain.Enums;

namespace FinanceSportApi.Domain.Entityes
{
    public class Transacao : Base
    {
        public string Valor { get; private set; }
        public DateTime Data { get; private set; }
        public TipoTransacao TipoTransacao { get; private set; } 
        public string Descricao { get; private set; }

        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; private set; }
    }
}