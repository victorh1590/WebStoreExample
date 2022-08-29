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

app.MapDefaultControllerRoute(); //MVC Endpoints.

app.Run();
