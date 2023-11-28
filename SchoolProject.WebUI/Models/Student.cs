using System.ComponentModel.DataAnnotations;

namespace SchoolProject.WebUI.Models
{
    public class Student
    {
        public int StudID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string DepartmentName { get; set; }
    }
}
