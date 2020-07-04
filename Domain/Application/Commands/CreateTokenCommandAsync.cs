using Contracts.RequestModels;
using Contracts.ResponseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Application.Commands
{
    public class CreateTokenCommandAsync : IRequest<Token>
    {
        public CreateTokenCommandAsync(TokenRequestModel tokenRequestModel)
        {
            TokenRequestModel = tokenRequestModel;
        }
        
        public TokenRequestModel TokenRequestModel { get; }
    }
}
