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
    options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindConnStr"));
});

var app = builder.Build();

if (builder.Environment.IsDevelopment() || builder.Environment.IsStaging())
    app.UseDeveloperExceptionPage();

//Configure
//app.MapGet("/", () => "Hello World!");
//app.MapGet("/hb", () => "<h1>Halk Bankası!<h1>");

app.UseStaticFiles();

app.MapDefaultControllerRoute();

app.Run();
