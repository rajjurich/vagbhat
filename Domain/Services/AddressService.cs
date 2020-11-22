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
    public interface IAddressService : IEntityRepository<Address>
    {
    }
    public class AddressService : IAddressService
    {
        private readonly IEntityRepository<Address> entityRepository;

        public AddressService(IEntityRepository<Address> entityRepository)
        {
            this.entityRepository = entityRepository;
        }
        public async Task<Address> AddAsync(Address entity)
        {
            return await entityRepository.AddAsync(entity);
        }

        public Task<int> CountAsync(Expression<Func<Address, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Address> Find(Expression<Func<Address, bool>> predicate, int? start, int? length)
        {
            return entityRepository.Find(predicate, start, length);
        }

        public IQueryable<Address> Get(int start, int length)
        {
            throw new NotImplementedException();
        }

        public Task<Address> GetAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task<Address> RemoveAsync(Address entity)
        {
            throw new NotImplementedException();
        }

        public Task<Address> UpdateAsync(Address entity)
        {
            return entityRepository.UpdateAsync(entity);
        }
    }
}
