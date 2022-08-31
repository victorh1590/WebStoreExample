using Microsoft.EntityFrameworkCore;
using Store.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); // Shared objects required for MVC/Razor

builder.Services.AddDbContext<StoreDbContext>(opts => // DB Service
{
  opts.UseSqlServer(builder.Configuration["ConnectionStrings:StoreConnection"]); // Retrieve connection string from appsettings.json
});

builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();

var app = builder.Build();

// app.MapGet("/", () => "Hello World!");

app.UseStaticFiles(); // Static files in wwwroot

app.MapControllerRoute("pagination", "Products/Page{productPage}", // Add new route for Index pages.
  new {
    Controller = "Home", action = "Index"
  });

app.MapDefaultControllerRoute(); //MVC Endpoints.

SeedData.EnsurePopulated(app); // Apply migrations and populates DB if empty.

app.Run();
