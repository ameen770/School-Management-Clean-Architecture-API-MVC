using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SchoolProject.Data.Entities
{
    public class Student
    {
        [Key]
        public int StudID { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Address { get; set; }
        [StringLength(500)]
        public string Phone { get; set; }
        public int? DID { get; set; }

        [ForeignKey("DID")]
        // [InverseProperty("Students")]
        public virtual Department Department { get; set; }


        // This is business processes

        /* // Additional properties for business processes
         public bool IsEnrolled { get; set; }
         public DateTime EnrollmentDate { get; set; }
         public List<Grade> Grades { get; set; }
         public List<AttendanceRecord> AttendanceRecords { get; set; }

         // Methods for business processes
         public void Enroll()
         {
             IsEnrolled = true;
             EnrollmentDate = DateTime.Now;
         }

         public void AddGrade(Grade grade)
         {
             if (Grades == null)
                 Grades = new List<Grade>();

             Grades.Add(grade);
         }

         public void MarkAttendance(AttendanceRecord attendanceRecord)
         {
             if (AttendanceRecords == null)
                 AttendanceRecords = new List<AttendanceRecord>();

             AttendanceRecords.Add(attendanceRecord);
         }

         public void UpdateAddress(string newAddress)
         {
             Address = newAddress;
         }

         public void UpdatePhone(string newPhone)
         {
             Phone = newPhone;
         }*/
    }

    /*public class AttendanceRecord
    {
        public DateTime Date { get; set; }
        public AttendanceStatus Status { get; set; }
        public string Remarks { get; set; }
    }

    public enum AttendanceStatus
    {
        Present,
        Absent,
        Late
    }


    public class Grade
    {
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
    }*/
}
