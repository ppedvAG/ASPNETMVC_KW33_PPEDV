using ASPNETCORE_IOC_SAMPLES.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


#region Initialisierung


// Add services to the container.

//MVC Framework wird verwendet -> Bei diesem Befehl sollte ein Controllers und Views - Verzeichnis exisitieren
builder.Services.AddControllersWithViews();

//WebAPI 
//builder.Services.AddControllers();

//Razor Page UI - Framework
builder.Services.AddRazorPages();

//MVC Framework + Razor Page UI
builder.Services.AddMvc(); //Intern wird AddControllersWithViews + AddRazorPages ausgeführt



//Wir legen den RequestCounter in den IOC Container ab
builder.Services.AddSingleton<IRequestCounter, RequestCounter>();
builder.Services.AddSingleton<DummyCar>();

#endregion
var app = builder.Build(); //Im Hintergrund wird -> IServiceProvider provider = collection.BuildServiceProvider(); aufgerufen

#region Frühester Zugriff in den IOC-Container -> z.B. Testdaten (InMemoryDatabase) 


//Variante 1
IRequestCounter? counter1 = app.Services.GetService<IRequestCounter>();  
IRequestCounter counter2 = app.Services.GetRequiredService<IRequestCounter>();
DummyCar car1 = app.Services.GetRequiredService<DummyCar>();



//Ältere Variante wurde in ASP.NET Core 2.1 eingeführt 

using (IServiceScope scope = app.Services.CreateScope())
{
    IRequestCounter? counter3 = scope.ServiceProvider.GetService<IRequestCounter>();
    IRequestCounter counter4 = scope.ServiceProvider.GetRequiredService<IRequestCounter>();

    DummyCar car2 = scope.ServiceProvider.GetRequiredService<DummyCar>();
}



#endregion



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
