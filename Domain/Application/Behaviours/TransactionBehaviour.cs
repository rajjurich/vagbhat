using Domain.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using vagbhat.api.Extensions;

namespace Domain.Application.Behaviours
{
    public class TransactionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> logger;

        public TransactionBehaviour(IUnitOfWork unitOfWork
            , ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var response = default(TResponse);
            var typeName = request.GetGenericTypeName();

            try
            {
                if (unitOfWork.HasActiveTransaction())
                {
                    return await next();
                }

                var strategy = unitOfWork.CreateExecutionStrategy();
                await strategy.ExecuteAsync(async () =>
                {
                    var transaction = await unitOfWork.BeginTransactionAsync();
                    response = await next();
                    await unitOfWork.CommitTransactionAsync(transaction);

                });

                return response;
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackTransactionAsync();
                logger.LogError(ex, "ERROR Handling transaction for {CommandName} ({@Command})", typeName, request);
                throw;
            }
        }
    }
}
