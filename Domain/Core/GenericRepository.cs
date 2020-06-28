using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T> EditAsync(T entity);        
        Task<T> GetAsync(string key);
        Task<T> DeleteAsync(T entity);        
    }
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EntitiesContext entitiesContext;

        public GenericRepository(DbContext entitiesContext)
        {
            this.entitiesContext = (EntitiesContext)entitiesContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await entitiesContext.Set<T>().AddAsync(entity);
            await entitiesContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            entitiesContext.Set<T>().Remove(entity);
            await entitiesContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> EditAsync(T entity)
        {
            entitiesContext.Entry(entity).State = EntityState.Modified;
            await entitiesContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> GetAsync(string key)
        {
            return await entitiesContext.Set<T>().FindAsync(key);
        }
    }
}
