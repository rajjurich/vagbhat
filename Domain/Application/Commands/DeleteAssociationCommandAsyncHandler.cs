using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Extensions;
using Domain.Options;
using Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Application.Commands
{
    public class DeleteAssociationCommandAsyncHandler : IRequestHandler<DeleteAssociationCommandAsync, AssociationDto>
    {
        private readonly IAssociationService service;
        private readonly IMapper mapper;

        public DeleteAssociationCommandAsyncHandler(IAssociationService service
            ,IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        public async Task<AssociationDto> Handle(DeleteAssociationCommandAsync request, CancellationToken cancellationToken)
        {
            var entity = await service.GetAsync(request.Id);
            var result= await service.RemoveAsync(entity);
            return mapper.Map<AssociationDto>(result);
        }
    }
}
