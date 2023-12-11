using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Implementations
{
    public class StudentService : IStudentService
    {
        #region Fields
        private readonly IStudentRepository _studentRepository;
        #endregion

        #region Constractors
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        
        #endregion

        #region Handles Functions
        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _studentRepository.GetStudentsListAsync();
        }

        // =================================

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            // var student = await _studentRepository.GetByIdAsync(id);
            var student = await _studentRepository.GetTableNoTracking()
                                                  .Include(x => x.Department)
                                                  .Where(s => s.StudID.Equals(id))
                                                  .FirstOrDefaultAsync();
            return student;
        }
        #endregion
    }
}
