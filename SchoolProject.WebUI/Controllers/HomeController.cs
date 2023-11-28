using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchoolProject.WebUI.Models;

public class HomeController : Controller
{
    private readonly HttpClient httpClient;
    private string BaseURL = "https://localhost:7136/Student/List";

    public HomeController()
    {
        httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("https://localhost:7136/Student/List"); // Replace with your Web API base URL
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
}