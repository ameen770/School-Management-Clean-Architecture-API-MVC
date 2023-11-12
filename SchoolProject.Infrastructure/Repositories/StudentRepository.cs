using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        #region Fields
        private readonly ApplicationDBContext _dBContext;
        #endregion

        #region Constructors
        public StudentRepository(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        #endregion

        #region Handles Functions
        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _dBContext.students.Include(x => x.Department).ToListAsync();
        }
        #endregion
    }
}
