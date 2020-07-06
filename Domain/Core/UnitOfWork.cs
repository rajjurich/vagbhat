using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public interface IUnitOfWork
    {
        Task BeginTransaction();
        Task Commit();
        Task Rollback();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EntitiesContext entitiesContext;
        IDbContextTransaction transaction;

        public UnitOfWork(EntitiesContext entitiesContext)
        {
            this.entitiesContext = entitiesContext;
        }
        public async Task BeginTransaction()
        {
            transaction = await entitiesContext.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            if (transaction != null)
            {
                await transaction.CommitAsync();
            }
        }

        public async Task Rollback()
        {
            if (transaction != null)
            {
                await transaction.RollbackAsync();
            }
        }
    }
}
