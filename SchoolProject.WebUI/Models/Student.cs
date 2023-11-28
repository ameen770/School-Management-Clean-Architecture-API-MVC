using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SchoolProject.WebUI.Models
{
    public class Student
    {
        [JsonProperty("studID")]
        public int StudID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("departmentName")]
        public string DepartmentName { get; set; }
    }
}
