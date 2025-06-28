using FinanceSportApi.Domain.Entityes;
using FinanceSportApi.Infra.Data.Context;

namespace FinanceSportApi.Infra.Data.Repository.Interface
{
    public class TransacaoRepository : BaseRepository<Transacao>, ITransacaoRepository
    {
        public TransacaoRepository(DataContext db) : base(db)
        {
        }
    }
}
