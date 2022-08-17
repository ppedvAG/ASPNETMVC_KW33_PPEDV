using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelloWebAPI.Data;
using HelloWebAPI.Shared.Entities;

namespace HelloWebAPI.Controllers
{


    /* URL Übersicht
     * GetAll:   https://localhost:12345/api/Movie/
     * GetMovie: https://localhost:12345/api/Movie/123
     * PutMovie: https://localhost:12345/api/Movie/123
     * PostMovie:https://localhost:12345/api/Movie/
     * DeleteMovie:https://localhost:12345/api/Movie/123
     * 
     * 
     * 
     */


    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieStoreDbContext _context;

        public MovieController(MovieStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/Movie
        [HttpGet] // HttpGet - HttpPost - HttpPut - HttpDelete ->sind alles HTTP-VERBS
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovie()
        {
            return await _context.Movie.ToListAsync();
        }

        // GET: api/Movie/5
        [HttpGet("{id}")] 
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [ProducesResponseType(201)]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = await _context.Movie.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // PUT: api/Movie/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie) //Movie movie -> modifieziertes Movie-Obj
        {
            if (id != movie.Id) //CrossSite Attacks Prüfung 
            {
                return BadRequest();
            }

            //EF Core -> Update eines Datensatues: Schritt 1 markeire Datensatz, dass diese modifiziert wurde
            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                //EF Core -> Update eines Datensatues: Schritt 2 übertragung zur Datenbank
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Movie
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie) //hier passiert Model-Binding -> Default-Lösung deckt alles ab
        {
            _context.Movie.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        // DELETE: api/Movie/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
