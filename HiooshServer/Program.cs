﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HiooshServer.Data;
using HiooshServer.Services;
var builder = WebApplication.CreateBuilder(args);

/*
builder.Services.AddDbContext<HiooshServerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HiooshServerContext") ?? throw new InvalidOperationException("Connection string 'HiooshServerContext' not found.")));
*/

// indection
builder.Services.AddSingleton<IRatingsService, RatingService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Ratings}/{action=Index}/{id?}");

app.Run();
