using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RedisProject.DAL.Interfaces
{
    public interface IGenericDal<TEntity> where TEntity : class, new()
    {
        Task<List<TEntity>> GetIncListAsync<TKey>(Expression<Func<TEntity, TKey>> keySelector);
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, TKey>> keySelector);
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter);
        Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> keySelector);
        Task<TEntity> GetIncAsync<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> keySelector);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
    }
}
