using FinanceSportApi.Domain.Entityes;
using FinanceSportApi.Infra.Data.Context;

namespace FinanceSportApi.Infra.Data.Repository.Interface
{
    public class OrcamentoRepository : BaseRepository<Orcamento>, IOrcamentoRepository
    {
        public OrcamentoRepository(DataContext db) : base(db)
        {
        }
    }
}
