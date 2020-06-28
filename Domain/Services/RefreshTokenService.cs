using Domain.Core;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IRefreshTokenService: IGenericRepository<RefreshToken>
    {
    }
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IGenericRepository<RefreshToken> genericRepository;

        public RefreshTokenService(IGenericRepository<RefreshToken> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task<RefreshToken> AddAsync(RefreshToken entity)
        {
            return await genericRepository.AddAsync(entity);
        }

        public async Task<RefreshToken> DeleteAsync(RefreshToken entity)
        {
            return await genericRepository.DeleteAsync(entity);
        }

        public async Task<RefreshToken> EditAsync(RefreshToken entity)
        {
            return await genericRepository.EditAsync(entity);
        }

        public async Task<RefreshToken> GetAsync(string key)
        {
            return await genericRepository.GetAsync(key);
        }
    }
}
