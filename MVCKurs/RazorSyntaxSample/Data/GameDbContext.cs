using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorSyntaxSample.Models;

namespace RazorSyntaxSample.Data
{
    public class GameDbContext : DbContext
    {
        public GameDbContext (DbContextOptions<GameDbContext> options)
            : base(options)
        {
        }

        public DbSet<RazorSyntaxSample.Models.Game> Game { get; set; } = default!;
    }
}
