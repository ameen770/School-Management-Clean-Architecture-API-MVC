﻿using MediatR;
using SchoolProject.Application.Bases;
using SchoolProject.Application.Features.Students.Queries.Results;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Features.Students.Queries.Models
{
    public class GetStudentListQuery : IRequest<Response<List<GetStudentListResponse>>>
    {
    }
}
