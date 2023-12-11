using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {     
        }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
        {
        }

        public DbSet<Student> students { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<StudentSubject> studentSubjects { get; set; }
        public DbSet<DepartmetSubject> departmetSubjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=AMEEN-DESKTOP;Database=SchoolDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");

    }
}
