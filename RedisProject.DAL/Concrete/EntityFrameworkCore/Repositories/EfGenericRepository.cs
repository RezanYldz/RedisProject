using Microsoft.EntityFrameworkCore;
using RedisProject.DAL.Concrete.EntityFrameworkCore.Context;
using RedisProject.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RedisProject.DAL.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : class, new()
    {
        public async Task<List<TEntity>> GetIncListAsync<TKey>(Expression<Func<TEntity, TKey>> keySelector)
        {
            using var context = new NorthwindContext();
            return await context.Set<TEntity>().Include(keySelector).ToListAsync();
        }
        public async Task<TEntity> GetIncAsync<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> keySelector)
        {
            using var context = new NorthwindContext();
            return await context.Set<TEntity>().Where(filter).Include(keySelector).FirstOrDefaultAsync();
        }
        public async Task AddAsync(TEntity entity)
        {
            using var context = new NorthwindContext();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            using var context = new NorthwindContext();
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new NorthwindContext();
            return await context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> keySelector)
        {
            using var context = new NorthwindContext();
            return await context.Set<TEntity>().Where(filter).OrderByDescending(keySelector).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, TKey>> keySelector)
        {
            using var context = new NorthwindContext();
            return await context.Set<TEntity>().OrderByDescending(keySelector).ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new NorthwindContext();
            return await context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            using var context = new NorthwindContext();
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            using var context = new NorthwindContext();
            context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
