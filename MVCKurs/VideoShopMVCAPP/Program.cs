using Microsoft.EntityFrameworkCore;
using VideoShopMVCAPP.Data;

namespace VideoShopMVCAPP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Hinzufügen unserer DBContext-Klasse, die mit dem MemoryDB-Provider zusammenarbeitet 
            builder.Services.AddDbContext<MovieDbContext>(options =>
            {
                //Angabe des Providers

                //Beispiel1: MemoryDB für Evaluierungsprojekte -> Package wird benötigt: Microsoft.EntityFrameworkCore.InMemory
                //options.UseInMemoryDatabase("MovieDb");

                //Beispiel 2: SQLServer -> Package: Microsoft.EntityFrameworkCore.SqlServer
                options.UseSqlServer(builder.Configuration.GetConnectionString("MovieDB"));

                //Wie kann ich Relationale Daten laden (mehrere Modies möglich)
            });

            var app = builder.Build();

            using (IServiceScope scope = app.Services.CreateScope())
                DataSeed.Initialize(scope.ServiceProvider);



            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}