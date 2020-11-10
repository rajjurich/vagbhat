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
    public interface IPatientService : IEntityRepository<Patient>
    {
    }
    public class PatientService : IPatientService
    {
        private readonly IEntityRepository<Patient> entityRepository;
        
        public PatientService(IEntityRepository<Patient> entityRepository)
        {
            this.entityRepository = entityRepository;           
        }
        public async Task<Patient> AddAsync(Patient entity)
        {
            return await entityRepository.AddAsync(entity);
        }

        public Task<int> CountAsync(Expression<Func<Patient, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Patient> Find(Expression<Func<Patient, bool>> predicate, int? start, int? length)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Patient> Get(int start, int length)
        {
            return entityRepository.Get(start, length);
        }

        public Task<Patient> GetAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task<Patient> RemoveAsync(Patient entity)
        {
            throw new NotImplementedException();
        }

        public Task<Patient> UpdateAsync(Patient entity)
        {
            throw new NotImplementedException();
        }
    }
}
