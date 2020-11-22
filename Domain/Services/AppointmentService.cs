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
    public interface IAppointmentService:IEntityRepository<Appointment>
    {
    }
    public class AppointmentService : IAppointmentService
    {
        private readonly IEntityRepository<Appointment> entityRepository;

        public AppointmentService(IEntityRepository<Appointment> entityRepository)
        {
            this.entityRepository = entityRepository;
        }
        public async Task<Appointment> AddAsync(Appointment entity)
        {
            return await entityRepository.AddAsync(entity);
        }

        public Task<int> CountAsync(Expression<Func<Appointment, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Appointment> Find(Expression<Func<Appointment, bool>> predicate, int? start, int? length)
        {
            return entityRepository.Find(predicate, start, length);
        }

        public IQueryable<Appointment> Get(int start, int length)
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> GetAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> RemoveAsync(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> UpdateAsync(Appointment entity)
        {
            return entityRepository.UpdateAsync(entity);
        }
    }
}
