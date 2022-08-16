using Microsoft.EntityFrameworkCore;
using VideoShopMVCAPP.Models;

namespace VideoShopMVCAPP.Data
{
    public class MovieDbContext : DbContext
    {

        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        { 
        }

        //Movies ist Tabellenname in DB
        public DbSet<Movie> Movies { get; set; }
    }
}
