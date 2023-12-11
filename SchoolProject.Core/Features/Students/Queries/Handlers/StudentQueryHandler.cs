using AutoMapper;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Application.Bases;
using SchoolProject.Application.Features.Students.Queries.Models;
using SchoolProject.Application.Features.Students.Queries.Results;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : ResponseHandler, 
        IRequestHandler<GetStudentListQuery, Response<List<GetStudentListResponse>>>,
        IRequestHandler<GetStudentByIdQuery, Response<GitSingleStudentResponse>>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        #endregion


        #region Constractors
        public StudentQueryHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        #endregion

        #region Handles Functions
        public async Task<Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _studentService.GetStudentsListAsync();
            var studentListMapper = _mapper.Map<List<GetStudentListResponse>>(studentList);
            return Success(studentListMapper);
        }

        public async Task<Response<GitSingleStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdAsync(request.Id);
            if (student == null) return NotFound<GitSingleStudentResponse>("Student Not Found");
            var result = _mapper.Map<GitSingleStudentResponse>(student);
            return Success(result);
        }
        #endregion
    }
}
