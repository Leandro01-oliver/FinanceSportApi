using FinanceSportApi.Domain.Entityes;
using FinanceSportApi.Infra.Data.Context;
using FinanceSportApi.Infra.Data.Repository.Interface;

namespace FinanceSportApi.Infra.Data.Repository
{
    public class InvestimentoRepository : BaseRepository<Investimento>, IInvestimentoRepository
    {
        public InvestimentoRepository(DataContext db) : base(db)
        {
        }
    }
}
