using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public interface IEntityRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync();
        Task<T> RemoveAsync(T entity);
        Task<T> UpdateAsync(T entity);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate, int? start, int? length);
        IQueryable<T> Get(int start, int length);
        Task<T> GetAsync(string key);
    }
    public class EntityRepository<T> : IEntityRepository<T> where T : class
    {
        private readonly EntitiesContext entitiesContext;

        public EntityRepository(EntitiesContext entitiesContext)
        {
            this.entitiesContext = entitiesContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await entitiesContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return await entitiesContext.Set<T>().Where(predicate).CountAsync();
        }

        public async Task<int> CountAsync()
        {
            return await entitiesContext.Set<T>().CountAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => entitiesContext.Entry(entity).State = EntityState.Modified);
            return entity;
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate, int? start, int? length)
        {
            if (start == null && length == null)
            {
                return entitiesContext.Set<T>().Where(predicate);
            }
            else
            {
                start = start < 0 ? 0 : start;
                length = length < 0 ? 10 : length > 1000 ? 1000 : length;
                return entitiesContext.Set<T>().Where(predicate).Skip((int)start).Take((int)length);
            }
        }

        public IQueryable<T> Get(int start, int length)
        {
            start = start < 0 ? 0 : start;
            length = length < 0 ? 10 : length > 1000 ? 1000 : length;
            return entitiesContext.Set<T>().Skip(start).Take(length);
        }

        public async Task<T> GetAsync(string key)
        {
            return await entitiesContext.Set<T>().FindAsync(key);
        }

        public async Task<T> RemoveAsync(T entity)
        {
            await Task.Run(() => entitiesContext.Set<T>().Remove(entity));
            return entity;
        }
    }
}
