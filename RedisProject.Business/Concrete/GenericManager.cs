using RedisProject.Business.Interfaces;
using RedisProject.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RedisProject.Business.Concrete
{
    public class GenericManager<TEntity> : IGenericService<TEntity> where TEntity : class, new()
    {
        IGenericDal<TEntity> _genericDal;
        public GenericManager(IGenericDal<TEntity> genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task<List<TEntity>> GetIncListAsync<TKey>(Expression<Func<TEntity, TKey>> keySelector)
        {
            return await _genericDal.GetIncListAsync(keySelector);
        }
        public async Task AddAsync(TEntity entity)
        {
            await _genericDal.AddAsync(entity);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _genericDal.GetAllAsync();
        }

        public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, TKey>> keySelector)
        {
            return await _genericDal.GetAllAsync(keySelector);
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _genericDal.GetAllAsync(filter);
        }

        public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> keySelector)
        {
            return await _genericDal.GetAllAsync(filter, keySelector);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _genericDal.GetAsync(filter);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            await _genericDal.RemoveAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _genericDal.UpdateAsync(entity);
        }

        public async Task<TEntity> GetIncAsync<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> keySelector)
        {
            return await _genericDal.GetIncAsync(filter, keySelector);
        }
    }
}
