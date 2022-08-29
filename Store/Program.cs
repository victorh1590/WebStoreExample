var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); // Shared objects required for MVC/Razor

var app = builder.Build();

// app.MapGet("/", () => "Hello World!");

app.UseStaticFiles(); // Static files in wwwroot

app.MapDefaultControllerRoute(); //MVC Endpoints.

app.Run();
