using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinanceSportApi.Infra.Data.Repository.Interface
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetObjectAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object?>>[]? includes);
        Task<(IEnumerable<TEntity> lista, int count)> GetPaginationAsync(Expression<Func<TEntity, bool>>? expression, int skip);
        Task<IEnumerable<TEntity>> GetObjectsAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object?>>[]? includes);
        Task AddAsync(TEntity entity);
        Task Update(TEntity entityUpdate, Expression<Func<TEntity, bool>>? expression);
        Task Remove(Expression<Func<TEntity, bool>>? expression);
    }
}
