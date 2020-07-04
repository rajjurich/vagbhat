using Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Application.Queries
{
    public class GetUserQueryAsync : IRequest<User>
    {
        public readonly string id;

        public GetUserQueryAsync(string id)
        {
            this.id = id;
        }
    }
}
