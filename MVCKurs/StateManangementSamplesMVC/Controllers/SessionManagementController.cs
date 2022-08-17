using Microsoft.AspNetCore.Mvc;
using StateManangementSamplesMVC.Models;

namespace StateManangementSamplesMVC.Controllers
{
    public class SessionManagementController : Controller
    {
        public IActionResult ViewDataSample()
        {
            ViewData["Id"] = 123;
            ViewData["Email"] = "kevinw@ppedv.de";
            ViewData.Add("ABC", 123);
            return View();
        }

        public IActionResult ViewBagSample()
        {
            ViewBag.Vornamen = "Mustermann";
            ViewBag.SchmitzKatze = "Meow";
            return View();
        }

        public IActionResult TempDataSample()
        {
            TempData["EmailAdresse"] = "kevinw@ppedv.de";
            TempData["Id"] = 123;

            TempData.Keep(); //Keep unterdrück das Löschen für eine einmalige weitere Benutzung
            return View();
        }

        public IActionResult TempDataSample1()
        {
            return View();
        }

        public IActionResult TempDataSample2()
        {
            return View();
        }

        public IActionResult SessionInit()
        {
            HttpContext.Session.SetInt32("Age", 33);
            HttpContext.Session.SetString("Name", "Mustermann");

            Person person1 = new Person() { ID = 123, Vorname = "Max", Nachname = "Mustermann" };

            string jsonString = System.Text.Json.JsonSerializer.Serialize(person1);

            HttpContext.Session.SetString("PersonObj", jsonString);
            return View();
        }

        
    }
}
