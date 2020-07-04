using Contracts.RequestModels;
using Contracts.ResponseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Application.Commands
{
    public class CreateRefreshTokenCommandAsync : IRequest<Token>
    {
        public CreateRefreshTokenCommandAsync(RefreshRequestModel refreshRequestModel)
        {
            RefreshRequestModel = refreshRequestModel;
        }

        public RefreshRequestModel RefreshRequestModel { get; }
    }
}
