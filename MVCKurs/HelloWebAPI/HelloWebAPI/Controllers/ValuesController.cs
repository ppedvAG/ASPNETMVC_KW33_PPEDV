using HelloWebAPI.Data;
using HelloWebAPI.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly MovieStoreDbContext _context;

        public ValuesController(MovieStoreDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [HttpPut]
        public async Task<IActionResult> InsertOrUpdate(Movie movie)
        {
            if (movie.Id == default)
            {
                //erstelle ein movie objekt
                _context.Movie.Add(movie);
                await _context.SaveChangesAsync();
            }
            else
            {
                //updat eines movie objektes
            }
            return Ok(movie);
        }
    }
}
