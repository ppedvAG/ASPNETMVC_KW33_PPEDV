using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HelloWebAPI.Shared.Entities;

namespace HelloWebAPI.Data
{
    public class MovieStoreDbContext : DbContext //DbContext ist eine Basisklasse aus dem EFCore
    {
        public MovieStoreDbContext (DbContextOptions<MovieStoreDbContext> options)
            : base(options)
        {
        }

        //DBSet repräsentiert eine Tabelle aus Datenbank
        public DbSet<HelloWebAPI.Shared.Entities.Movie> Movie { get; set; }
    }
}
