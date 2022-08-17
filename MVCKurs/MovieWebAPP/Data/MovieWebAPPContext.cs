using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieWebAPP.Models;

namespace MovieWebAPP.Data
{
    public class MovieWebAPPContext : DbContext
    {
        public MovieWebAPPContext (DbContextOptions<MovieWebAPPContext> options)
            : base(options)
        {
        }

        public DbSet<MovieWebAPP.Models.Movie> Movie { get; set; } = default!;
    }
}
