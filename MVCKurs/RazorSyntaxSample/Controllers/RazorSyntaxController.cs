using Microsoft.AspNetCore.Mvc;
using RazorSyntaxSample.Models;
using RazorSyntaxSample.ViewModels;

namespace RazorSyntaxSample.Controllers
{
    public class RazorSyntaxController : Controller
    {

        //GET-METHODE
        public IActionResult RazorSamplesOverview()
        {
            Person person = new Person { Id = 1, FirstName = "Max", LastName = "Mustermann" };
            return View(person);
        }

        //GET-METHODE
        public IActionResult TableSampleWithModel()
        {
            IList<Person> persons = new List<Person>();
            persons.Add(new Person { Id = 1, FirstName = "Andre", LastName = "Ruhland" });
            persons.Add(new Person { Id = 2, FirstName = "Hannes", LastName = "Preishuber" });
            return View(persons);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Ermittle den Datensatz für Details 

            //Verwenden hier ein Test-Objekt

            Person p = new Person { Id = id.Value, FirstName = "Max", LastName = "Moritz" };

            return View(p);
        }

        //GET-METHODE
        public IActionResult TableSampleWithViewModel()
        {

            MovieViewModel vm = new MovieViewModel();

            vm.Movie = new Movie
            {
                Id = 1,
                Title = "Jurrasic Park",
                Description = "TRex wird Veggie",
                Price = 19.99m
            };

            vm.Cast = new List<Artists>();
            vm.Cast.Add(new Artists
            {
                Id = 1,
                FirstName = "Otto",
                LastName = " Walkes"
            });

            vm.Cast.Add(new Artists
            {
                Id = 2,
                FirstName = "Harry",
                LastName = " Weinfuhrt"
            });

            vm.Cast.Add(new Artists
            {
                Id = 3,
                FirstName = "Ralf",
                LastName = " Möller"
            });

            vm.ExterneIMDBRating = 8;

            return View(vm);

        }

        public IActionResult ShowSimplePartialView()
        {
            return View();
        }

    }
}
