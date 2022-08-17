using Microsoft.AspNetCore.Mvc;
using StateManangementSamplesMVC.Models;
using System.Diagnostics;
using System.Text.Json;

namespace StateManangementSamplesMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SessionResult()
        {
            string Name = HttpContext.Session.GetString("Name");
            int? Alter = HttpContext.Session.GetInt32("Age");

            string jsonString = HttpContext.Session.GetString("PersonObj");
            Person person = JsonSerializer.Deserialize<Person>(jsonString);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}