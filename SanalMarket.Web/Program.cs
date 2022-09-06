using Microsoft.EntityFrameworkCore;
using SanalMarket.Infrastructure.Abstract;
using SanalMarket.Infrastructure.Concrete;
using SanalMarket.Infrastructure.Contexts;

var builder = WebApplication.CreateBuilder(args);
//ConfigureServices

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductService, EfProductService>();
builder.Services.AddDbContext<NorthwindContext>(options =>
{
    options.UseSqlServer("Data Source=.; Initial Catalog=Northwind; Integrated Security=true;");
});


var app = builder.Build();

//Configure
//app.MapGet("/", () => "Hello World!");
//app.MapGet("/hb", () => "<h1>Halk Bankası!<h1>");

app.MapDefaultControllerRoute();

app.Run();
