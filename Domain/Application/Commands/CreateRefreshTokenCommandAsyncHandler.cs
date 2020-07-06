﻿using Domain.Core;
using Domain.Dtos;
using Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Application.Commands
{
    public class CreateRefreshTokenCommandAsyncHandler : IRequestHandler<CreateRefreshTokenCommandAsync, TokenDto>
    {
        private readonly IAccessService userService;
        private readonly IUnitOfWork unitOfWork;

        public CreateRefreshTokenCommandAsyncHandler(IAccessService accessService
            ,IUnitOfWork unitOfWork)
        {
            this.userService = accessService;
            this.unitOfWork = unitOfWork;
        }

        

        public async Task<TokenDto> Handle(CreateRefreshTokenCommandAsync request, CancellationToken cancellationToken)
        {
            //await unitOfWork.BeginTransaction();
            return await userService.CreateRefreshTokenAsync(request);
        }
    }
}