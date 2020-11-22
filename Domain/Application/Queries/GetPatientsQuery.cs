﻿using Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Application.Queries
{
    public class GetPatientsQuery : IRequest<IQueryable<PatientDto>>
    {
        public GetPatientsQuery()
        {
           
        }       
    }
}