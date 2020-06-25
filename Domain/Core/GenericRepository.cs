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
        IQueryable<T> Get();
        Task<T> GetAsync(int key);
        Task<T> DeleteAsync(int key);
        Task<T> IsExistAsync(string key);
    }
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext entitiesContext;

        public GenericRepository(DbContext entitiesContext)
        {
            this.entitiesContext = entitiesContext;
        }
        public Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> EditAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Get()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(int key)
        {
            throw new NotImplementedException();
        }

        public Task<T> IsExistAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteAsync(int key)
        {
            throw new NotImplementedException();
        }
    }
}
