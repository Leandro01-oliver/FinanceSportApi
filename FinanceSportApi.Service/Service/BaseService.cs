using AutoMapper;
using FinanceSportApi.Infra.Data.Repository.Interface;
using FinanceSportApi.Service.Service.Interface;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;

namespace FinanceSportApi.Service.Service
{
    public class BaseService<TVm, TEntity>(IBaseRepository<TEntity> repository, IMapper mapper) : IBaseService<TVm, TEntity>
        where TVm : class
        where TEntity : class
    {
        protected readonly IBaseRepository<TEntity> _repository = repository;
        protected readonly IMapper _mapper = mapper;

        public async Task AddAsync(TVm vm)
        {
            try
            {
                var model = _mapper.Map<TEntity>(vm);
                await _repository.AddAsync(model);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<TVm> GetObjectAsync(Expression<Func<TVm, bool>> expression, params Expression<Func<TVm, object?>>[]? includes)
        {
            try
            {
                var result = await _repository.GetObjectAsync(
                        _mapper.Map<Expression<Func<TEntity, bool>>>(expression),
                        _mapper.Map<Expression<Func<TEntity, object>>[]>(includes));
                return _mapper.Map<TVm>(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<TVm>> GetObjectsAsync(Expression<Func<TVm, bool>> expression, params Expression<Func<TVm, object?>>[]? includes)
        {
            try
            {
                var result = await _repository.GetObjectAsync(
                        _mapper.Map<Expression<Func<TEntity, bool>>>(expression),
                        _mapper.Map<Expression<Func<TEntity, object>>[]>(includes));
                return _mapper.Map<IEnumerable<TVm>>(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<(IEnumerable<TVm> lista, int count)> GetPaginationAsync(Expression<Func<TVm, bool>>? expression, int skip)
        {
            try
            {
                var result = await _repository.GetPaginationAsync(
                           _mapper.Map<Expression<Func<TEntity, bool>>>(expression),
                           skip);
                return _mapper.Map<(IEnumerable<TVm> lista, int count)>(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task Remove(Expression<Func<TVm, bool>>? expression)
        {
            try
            {
                await _repository.Remove(_mapper.Map<Expression<Func<TEntity, bool>>>(expression));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task Update(TVm vmUpdate, Expression<Func<TVm, bool>>? expression)
        {
            try
            {
                await _repository.Update(_mapper.Map<TEntity>(vmUpdate), _mapper.Map<Expression<Func<TEntity, bool>>>(expression));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
