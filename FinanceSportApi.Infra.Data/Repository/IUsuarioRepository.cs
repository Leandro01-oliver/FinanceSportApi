using FinanceSportApi.Domain.Entityes;
using FinanceSportApi.Infra.Data.Context;

namespace FinanceSportApi.Infra.Data.Repository.Interface
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DataContext db) : base(db)
        {
        }
    }
}
