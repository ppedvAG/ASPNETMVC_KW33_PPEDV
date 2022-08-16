using ConfigurationSampleApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigurationSampleApp.Controllers
{
    public class ConfigurationSampleController : Controller
    {
        // IActionResult / ActionResult
        //Get-Methoden in MVC benötigen immer eine View
        public IActionResult ReadExplicitFromICollectionSample([FromServices] IConfiguration configuration)
        {
            string myKeyValue = configuration["MyKey"];
            string title = configuration["Position:Title"];
            string name = configuration["Position:Name"];
            string defaultLogLevel = configuration["Logging:LogLevel:Default"];

            return View();
        }

       
        

        //Option-Pattern: - ISnapshot ermöglicht das automatische Nachladen von Konfiguration
        public IActionResult ReadWithPositionOptionsAsOptionPattern([FromServices] IOptionsSnapshot<PositionOptions> positionOptions)
        {
            return View(positionOptions.Value);
        }

        /*
         * 
         * ContentResult -> Ausgabe als String
         * 
         * 
         */
        public ContentResult ShowArray([FromServices] IOptionsSnapshot<ArrayExample> myArray)
        {
            string str = string.Empty;

            foreach (string arrayEntry in myArray.Value.Entries)
                str = str + arrayEntry + "\n";

            return Content(str); //Ausgabe des kompletten Arrays 
        }

        public IActionResult ReadArrayConfigFile([FromServices] IOptionsSnapshot<ArrayExample> myArray)
        {
            return View(myArray.Value);
        }
    }
}
