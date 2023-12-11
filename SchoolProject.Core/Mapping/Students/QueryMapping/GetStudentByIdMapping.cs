using SchoolProject.Application.Features.Students.Queries.Results;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Mapping.Students
{
    public partial class StudentProfile
    {
        public void GetStudentByIdMapping()
        {
            CreateMap<Student, GitSingleStudentResponse>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DName));
        }
    }
}
