using FinanceSportApi.Infra.Data.Context;
using FinanceSportApi.Infra.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinanceSportApi.Infra.Data.Repository
{
    public class BaseRepository<TEntity>(DataContext db) : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DataContext _db = db;
        protected readonly DbSet<TEntity> _dbSet = db.Set<TEntity>();

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<TEntity> GetObjectAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object?>>[]? includes)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();

            if (includes is not null && includes.Length != 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(PropertyPath(include));
                }
            }

            return await query.FirstOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<TEntity>> GetObjectsAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object?>>[]? includes)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();

            if (includes is not null && includes.Length != 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(PropertyPath(include));
                }
            }

            var result = expression == null
                ? await query.AsNoTracking().ToListAsync()
                : await query.AsNoTracking().Where(expression).ToListAsync();

            return result;
        }


        public async Task<(IEnumerable<TEntity> lista, int count)> GetPaginationAsync(Expression<Func<TEntity, bool>>? expression, int skip)
        {
            var query = _dbSet.AsNoTracking();

            if (expression != null)
                query = query.Where(expression);

            query = query.OrderBy(x => EF.Property<DateTime>(x, "DtCadastro")).Skip(skip).Take(5);

            var lista = await query.ToListAsync();
            var count = await _dbSet.CountAsync(expression ?? (_ => true));

            return (lista, count);
        }

        public async Task Remove(Expression<Func<TEntity, bool>>? expression)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            TEntity? entity = await query.FirstOrDefaultAsync(expression);
            _db.Remove(entity);
        }

        public async Task Update(TEntity entityUpdate, Expression<Func<TEntity, bool>>? expression)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            TEntity? entity = await query.FirstOrDefaultAsync(expression);
            entity = entityUpdate;
            _db.Remove(entity);
        }

        public static string PropertyPath<TSource, TProperty>(Expression<Func<TSource, TProperty>> expression)
        {
            return GetFullPropertyPath(expression.Body);
        }

        private static string GetFullPropertyPath(Expression? expression)
        {
            if (expression is MemberExpression memberExpression)
            {
                var parentPath = GetFullPropertyPath(memberExpression.Expression);
                return string.IsNullOrEmpty(parentPath) ? memberExpression.Member.Name : $"{parentPath}.{memberExpression.Member.Name}";
            }

            if (expression is UnaryExpression unaryExpression)
            {
                return GetFullPropertyPath(unaryExpression.Operand);
            }

            if (expression is MethodCallExpression methodCallExpression)
            {
                return ExtractSelectMemberPath(methodCallExpression);
            }

            return string.Empty;
        }
        public static string ExtractSelectMemberPath(MethodCallExpression methodCallExpression)
        {
            if (methodCallExpression.Method.Name == "Select" && methodCallExpression.Arguments.Count == 2)
            {
                var lambdaExpression = ExtractLambdaExpression(methodCallExpression.Arguments[1]);
                if (lambdaExpression != null)
                {
                    var selectPart = GetFullPropertyPath(lambdaExpression.Body);
                    var pathBeforeSelect = GetFullPropertyPath(methodCallExpression.Arguments[0]);

                    return $"{pathBeforeSelect}.{selectPart}";
                }
            }

            return GetFullPropertyPath(methodCallExpression.Arguments[0]);
        }
        private static LambdaExpression? ExtractLambdaExpression(Expression expression)
        {
            if (expression is LambdaExpression lambdaExpression)
            {
                return lambdaExpression;
            }

            if (expression is UnaryExpression unaryExpression && unaryExpression.Operand is LambdaExpression innerLambdaExpression)
            {
                return innerLambdaExpression;
            }

            return null;
        }
    }
}
