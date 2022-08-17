using HelloWebAPI.Shared.MockObjects;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HelloWebAPI.Data;

namespace HelloWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);


            // Hier können wir neue WebAPI/ASPNETCore Features freischalten.

            // Wir verwenden WebAPI
            //services.AddControllersWithViews(); //MVC 
            //services.AddRazorPages(); //Razor Page 
            //services.AddMvc(); // MVC + Razor Page 

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HelloWebAPI", Version = "v1" });
            });

            //Weitere Libraries k�nnen hier hinzugef�gt werden. 

            services.AddSingleton<ICar, MockCar>();

            services.AddDbContext<MovieStoreDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("MovieStoreDbContext")));

            //Wenn ICar doppelt angegeben wird, gewinnt das Letzte!
            //services.AddSingleton<ICar, Car>(); 
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HelloWebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
