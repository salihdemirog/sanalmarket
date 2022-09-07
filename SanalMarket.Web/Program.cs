using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using SanalMarket.Infrastructure.Abstract;
using SanalMarket.Infrastructure.Concrete;
using SanalMarket.Infrastructure.Contexts;
using SanalMarket.Web;

var builder = WebApplication.CreateBuilder(args);
//ConfigureServices

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductService, EfProductService>();
builder.Services.AddDbContext<NorthwindContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindConnStr"));
});

var app = builder.Build();

//Configure

app.UseLogMiddleware();

if (builder.Environment.IsDevelopment() || builder.Environment.IsStaging())
    app.UseDeveloperExceptionPage();

app.UseStaticFiles();

app.MapControllerRoute(name: "default", pattern: "{controller=Product}/{action=Index}");

app.Run();
