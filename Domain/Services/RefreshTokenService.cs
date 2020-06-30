using Domain.Core;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IRefreshTokenService: IEntityRepository<RefreshToken>
    {
    }
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IEntityRepository<RefreshToken> entityRepository;

        public RefreshTokenService(IEntityRepository<RefreshToken> entityRepository)
        {
            this.entityRepository = entityRepository;
        }

        public async Task<RefreshToken> AddAsync(RefreshToken entity)
        {
            return await entityRepository.AddAsync(entity);
        }

        public async Task<int> CountAsync(Expression<Func<RefreshToken, bool>> predicate)
        {
            return await entityRepository.CountAsync(predicate);
        }

        public async Task<int> CountAsync()
        {
            return await entityRepository.CountAsync();
        }

        public async Task<RefreshToken> DeleteAsync(RefreshToken entity)
        {
            return await entityRepository.DeleteAsync(entity);
        }

        public async Task<RefreshToken> EditAsync(RefreshToken entity)
        {
            return await entityRepository.EditAsync(entity);
        }

        public IQueryable<RefreshToken> Find(Expression<Func<RefreshToken, bool>> predicate, int start, int length)
        {
            return entityRepository.Find(predicate, start, length);
        }

        public IQueryable<RefreshToken> Get(int start, int length)
        {
            return entityRepository.Get(start, length);
        }

        public async Task<RefreshToken> GetAsync(string key)
        {
            return await entityRepository.GetAsync(key);
        }
    }
}
