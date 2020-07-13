using Domain.Core;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IAssociationService: IEntityRepository<Association>
    {
    }
    public class AssociationService : IAssociationService
    {
        private readonly IEntityRepository<Association> entityRepository;

        public AssociationService(IEntityRepository<Association> entityRepository)
        {
            this.entityRepository = entityRepository;
        }
        public async Task<Association> AddAsync(Association entity)
        {
            return await entityRepository.AddAsync(entity);
        }

        public async Task<int> CountAsync(Expression<Func<Association, bool>> predicate)
        {
            return await entityRepository.CountAsync(predicate);
        }

        public async Task<int> CountAsync()
        {
            return await entityRepository.CountAsync();
        }

        public async Task<Association> RemoveAsync(Association entity)
        {
            return await entityRepository.RemoveAsync(entity);
        }

        public async Task<Association> UpdateAsync(Association entity)
        {
            return await entityRepository.UpdateAsync(entity);
        }

        public IQueryable<Association> Find(Expression<Func<Association, bool>> predicate, int start, int length)
        {
            return entityRepository.Find(predicate, start, length);
        }

        public IQueryable<Association> Get(int start, int length)
        {
            return entityRepository.Get(start, length);
        }

        public async Task<Association> GetAsync(string key)
        {
            return await entityRepository.GetAsync(key);
        }
    }
}
