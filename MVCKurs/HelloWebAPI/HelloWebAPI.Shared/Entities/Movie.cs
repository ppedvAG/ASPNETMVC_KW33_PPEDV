using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWebAPI.Shared.Entities
{
    public class Movie
    {
        public int Id { get; set; } //EF Core erkennt anhand des Namens, ob es sich um einen Primary Key handelt.
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
