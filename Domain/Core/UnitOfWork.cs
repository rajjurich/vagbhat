using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public interface IUnitOfWork
    {
        Task<IDbContextTransaction> BeginTransactionAsync();
        bool HasActiveTransaction();
        Task CommitTransactionAsync(IDbContextTransaction transaction);
        Task RollbackTransactionAsync();
        IExecutionStrategy CreateExecutionStrategy();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EntitiesContext entitiesContext;
        IDbContextTransaction currentTransaction;

        public UnitOfWork(EntitiesContext entitiesContext)
        {
            this.entitiesContext = entitiesContext;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            currentTransaction = await entitiesContext.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);
            return currentTransaction;
        }

        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null)
            {
                throw new ArgumentNullException(nameof(transaction));
            }
            if (transaction != currentTransaction)
            {
                throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");
            }

            if (currentTransaction != null)
            {
                try
                {
                    await entitiesContext.SaveChangesAsync();
                    await currentTransaction.CommitAsync();
                }
                catch
                {
                    await RollbackTransactionAsync();
                    throw;
                }
                finally
                {
                    if (currentTransaction != null)
                    {
                        currentTransaction.Dispose();
                        currentTransaction = null;
                    }
                }

            }
        }

        public IExecutionStrategy CreateExecutionStrategy()
        {
            return entitiesContext.Database.CreateExecutionStrategy();
        }

        public bool HasActiveTransaction()
        {
            return currentTransaction != null;
        }

        public async Task RollbackTransactionAsync()
        {
            if (currentTransaction != null)
            {
                try
                {
                    await currentTransaction?.RollbackAsync();
                }
                finally
                {
                    if (currentTransaction != null)
                    {
                        currentTransaction.Dispose();
                        currentTransaction = null;
                    }
                }
            }
        }
    }
}
