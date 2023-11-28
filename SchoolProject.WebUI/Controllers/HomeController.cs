using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using SchoolProject.WebUI.Models;

public class HomeController : Controller
{
    private readonly HttpClient httpClient;
    //HttpClient _client = new HttpClient();
    private string BaseURL = "https://localhost:7136/Student/List";

    public HomeController()
    {
        httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(BaseURL); // Replace with your Web API base URL
    }

    public async Task<ActionResult> Index()
    {
        List<Student> students = new List<Student>();

        try
        {
            HttpResponseMessage response = await httpClient.GetAsync(BaseURL); // Replace with your Web API endpoint URL

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                students = JsonConvert.DeserializeObject<List<Student>>(responseContent);
            }
            else
            {
                // Handle the error response
                // For example, you can log the error or display an error message
                // response.StatusCode and response.ReasonPhrase provide additional information
            }
        }
        catch (Exception ex)
        {
            // Handle the exception
        }

        return View(students);
    }

    public async Task<IActionResult> AddStudent()
    {
        Student student = new Student();
        List<Student> students = new List<Student>();
        var json = System.Text.Json.JsonSerializer.Serialize(student);
        HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

        // var response = await httpClient.PutAsync(BaseURL, content);
        var response = await httpClient.PostAsync(BaseURL, content);
        if (response.IsSuccessStatusCode)
        {
            string view = await response.Content.ReadAsStringAsync();
            if (!string.IsNullOrEmpty(view))
            {
                return View(students);
            }
            else
            {
                return View(student);
            }
        }
        else
        {
            return View(student);
        }
    }
}