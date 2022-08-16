using VideoShopMVCAPP.Models;

namespace VideoShopMVCAPP.Data
{
    public static class DataSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            MovieDbContext ctx = serviceProvider.GetRequiredService<MovieDbContext>();

            //Ist die Tabelle Movies leer? 
            if (!ctx.Movies.Any())
            {

                //UNIT OF WORK -> DESIGN PATTERN 
                //Bedeutet: Speichern/Updaten/Löschen in 2 Schritten

                //Schritt 1: Wir markieren den Datensatz, dass dieser Hinzugefügt wird
                ctx.Movies.Add(new Movie() { Title = "Jurassic Park", Description = "T-Rex wird zu Veggie", Price = 10, Genre = GenreTyp.Action });
                ctx.Movies.Add(new Movie() { Title = "Jurassic Park 2", Description = "Das Dinoei", Price = 12, Genre = GenreTyp.Action });

                //Schritt 2: Wir übertragen die Datensätze Richtung Datenbank
                ctx.SaveChanges();
            }

        }
    }
}
