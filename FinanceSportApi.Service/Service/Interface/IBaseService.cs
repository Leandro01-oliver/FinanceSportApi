using System.Linq.Expressions;

namespace FinanceSportApi.Service.Service.Interface
{
    public interface IBaseService<TVm, TEntity> where TVm : class where TEntity : class
    {
        Task<TVm> GetObjectAsync(Expression<Func<TVm, bool>> expression, params Expression<Func<TVm, object?>>[]? includes);
        Task<(IEnumerable<TVm> lista, int count)> GetPaginationAsync(Expression<Func<TVm, bool>>? expression, int skip);
        Task<IEnumerable<TVm>> GetObjectsAsync(Expression<Func<TVm, bool>> expression, params Expression<Func<TVm, object?>>[]? includes);
        Task AddAsync(TVm vm);
        Task Update(TVm vmUpdate, Expression<Func<TVm, bool>>? expression);
        Task Remove(Expression<Func<TVm, bool>>? expression);
    }
}
