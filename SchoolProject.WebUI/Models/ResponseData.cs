namespace SchoolProject.WebUI.Models
{
    public class ResponseData
    {
        public int StatusCode { get; set; }
        public object Meta { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public object Errors { get; set; }
        public List<Student> Data { get; set; }
    }
}
