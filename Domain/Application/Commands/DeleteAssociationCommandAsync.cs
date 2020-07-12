﻿using Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Application.Commands
{
    public class DeleteAssociationCommandAsync : IRequest<AssociationDto>
    {
        public DeleteAssociationCommandAsync(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
