using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoShopMVCAPP.Data;
using VideoShopMVCAPP.Models;

namespace VideoShopMVCAPP.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieDbContext _ctx;

        /// <summary>
        /// Konstruktor mit Konstruktor-Injections
        /// </summary>
        /// <param name="movieDbContext">MovieDBContext wird aus IOC Container gelesen</param>
        public MovieController(MovieDbContext movieDbContext)
        {
            _ctx = movieDbContext;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter">Textbox hat den Namen filter und wir wollen den Wert als Parameter</param>
        /// <returns></returns>
        public IActionResult Index(string filter)
        {
            //Steht in Filter ein Suchbegriff drin
            if (!string.IsNullOrEmpty(filter))
            {
                //Suchbegriff wird mit übergeben 
                ViewData["FilterQuery"] = filter;
                return View(_ctx.Movies.Where(q => q.Title.Contains(filter) || q.Description.Contains(filter)));
            }
            return View(_ctx.Movies.ToList());
        }


        //GET-METHODE -> Eine leeres Formular wird eingezeigt
        [HttpGet]
        public IActionResult Create()
        {
            return View(); 
        }

        //POST-METHODE -> Formular wird augewertet
        [HttpPost]
        public IActionResult Create(Movie movie) //Movie movie ist das Ergebis der Formulareingabe-> Es wird von MVC ein fertiges Objekt gebaut
        {
            //So bitte nicht machen, geht aber auch! 
            string alternativerWeg = HttpContext.Request.Form["Title"];




            //Regeln
            if (movie.Title == "The Crow")
            {
                ModelState.AddModelError("Title", "Der Film steht auf dem Index");
            }


            //Server Seitige Validierung
            if (ModelState.IsValid)
            {
                #region Speichere validen Datensatz in DB
                //Frage, Zugriff auf SP in MSSQL 
                //string sql = "EXEC SalesLT.Product_GetAll";
                //list = _ctx.Movies.FromSqlRaw<Movie>(sql).ToList();

                _ctx.Movies.Add(movie);
                _ctx.SaveChanges();

                #endregion

                return RedirectToAction(nameof(Index));
            }

            return View(movie);
        }


    }
}
