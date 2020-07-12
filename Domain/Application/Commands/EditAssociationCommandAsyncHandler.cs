using Domain.Dtos;
using Domain.Entities;
using Domain.Extensions;
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
    public class EditAssociationCommandAsyncHandler : IRequestHandler<EditAssociationCommandAsync, AssociationDto>
    {
        private readonly IAssociationService service;

        public EditAssociationCommandAsyncHandler(IAssociationService service)
        {
            this.service = service;
        }
        public async Task<AssociationDto> Handle(EditAssociationCommandAsync request, CancellationToken cancellationToken)
        {
            var result = await service.EditAsync(request.Dto.ToAssociation());
            return result.ToAssociationDto();
        }
    }
}
