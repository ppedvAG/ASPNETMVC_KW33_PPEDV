
using ASPNETCORE_IOC_SAMPLES.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCORE_IOC_SAMPLES.Controllers
{

    //Ein Controller bedient mehrere Views
    public class IOCSampleController : Controller
    {
        //Wie greifen wir auf den IOC Container zu
        private readonly IRequestCounter requestCounter;

        //Mihilfe des Konstruktor -> Konstrutor-Injection 
        //Konstruktor Injection wird verwendet, wenn fast jede Methode im Controller den Dienst verwenden möchte. 

        public IOCSampleController(IRequestCounter requestCounter)
        {
            this.requestCounter = requestCounter;
        }


        //FromServices wird verwendet, wenn in einer Methode einen speziellen Dienst zu verwenden. 
        public IActionResult Index([FromServices] IRequestCounter requestCounter)
        {
            requestCounter.IncrementCounter(); //Wir erhöhren den Counter um den Wert '1'

            return View(requestCounter.Counter); //Übergeben den Counter an die View
        }


        //GET-METHODE
        public IActionResult Sample2()
        {

            //Nullable fähig
            IRequestCounter? requestCounter1 = this.HttpContext.RequestServices.GetService<IRequestCounter>();

            //Exception
            IRequestCounter requestCounter2 = this.HttpContext.RequestServices.GetRequiredService<IRequestCounter>();
            requestCounter2.IncrementCounter();


            return View(requestCounter2.Counter); //Counter-Wert wird an View übergeben 
        }

        public IActionResult Sample3()
        {
            return View();
        }
    }
}
