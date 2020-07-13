using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Extensions;
using Domain.Options;
using Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Application.Commands
{
    public class CreateAssociationCommandAsyncHandler : IRequestHandler<CreateAssociationCommandAsync, AssociationDto>
    {
        private readonly IAssociationService service;
        private readonly IMapper mapper;

        public CreateAssociationCommandAsyncHandler(IAssociationService service
            , IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        public async Task<AssociationDto> Handle(CreateAssociationCommandAsync request, CancellationToken cancellationToken)
        {
            var result = await service.AddAsync(mapper.Map<Association>(request.Dto));           
            return mapper.Map<AssociationDto>(result);
        }
    }
}
