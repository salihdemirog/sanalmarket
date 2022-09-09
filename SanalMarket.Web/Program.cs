using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using SanalMarket.Infrastructure.Abstract;
using SanalMarket.Infrastructure.Concrete;
using SanalMarket.Infrastructure.Contexts;
using SanalMarket.Web.CartManagement;
using SanalMarket.Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);
//ConfigureServices

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductService, EfProductService>();
builder.Services.AddScoped<ICategoryService, EfCategoryService>();
builder.Services.AddScoped<IUserService, EfUserService>();
builder.Services.AddScoped<ICartService, SessionCartService>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddSession(options =>
{
    options.Cookie.Name = "HalkMarket.Session";
});

builder.Services.AddDbContext<NorthwindContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindConnStr"));
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {

    });

var app = builder.Build();

//Configure

app.UseLogMiddleware();

if (builder.Environment.IsDevelopment() || builder.Environment.IsStaging())
    app.UseDeveloperExceptionPage();

app.UseStaticFiles();

app.UseSession();

app.UseAuthentication();

app.MapControllerRoute(name: "default", pattern: "{controller=Product}/{action=Index}");

app.Run();
