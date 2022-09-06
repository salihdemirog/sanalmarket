var builder = WebApplication.CreateBuilder(args);
//ConfigureServices

builder.Services.AddControllersWithViews();

var app = builder.Build();

//Configure
//app.MapGet("/", () => "Hello World!");
//app.MapGet("/hb", () => "<h1>Halk Bankası!<h1>");

app.MapDefaultControllerRoute();

app.Run();
