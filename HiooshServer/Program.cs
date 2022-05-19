using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HiooshServer.Data;
using HiooshServer.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

/*
builder.Services.AddDbContext<HiooshServerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HiooshServerContext") ?? throw new InvalidOperationException("Connection string 'HiooshServerContext' not found.")));
*/

// indection
builder.Services.AddSingleton<IRatingsService, RatingService>();

builder.Services.AddSingleton<IContactsService, ContactService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

/*
// for the cookie
builder.Services.AddAuthentication(options => {
    options.DefaultScheme = "Cookies";
}).AddCookie("Cookies", options => {
    options.Cookie.Name = "Cookie_Name";
    options.Cookie.SameSite = SameSiteMode.None;
    options.Events = new CookieAuthenticationEvents
    {
        OnRedirectToLogin = redirectContext =>
        {
            redirectContext.HttpContext.Response.StatusCode = 401;
            return Task.CompletedTask;
        }
    };
});*/

builder.Services.AddCors(options =>
{
    options.AddPolicy("Allow All",
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
});

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(40);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseCors("Allow All");

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Ratings}/{action=Index}/{id?}");
/*
 for the coockies
app.UseCookiePolicy(
    new CookiePolicyOptions
    {
        Secure = CookieSecurePolicy.Always
    });
// for the cookie
app.UseAuthentication();
app.UseAuthorization();*/

app.Run();
