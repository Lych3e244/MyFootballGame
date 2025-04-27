using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using MyFootballGame.Other.Application;
using MyFootballGame.Other.Application.ViewModel.League;
using MyFootballGame.Other.Domain.Interfaces;
using MyFootballGame.Other.Infrastructure;
using MyFootballGame.Other.Infrastructure.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using System.Web.WebPages;
using MyFootballGame.Other.Application.ViewModel.Season;
using MyFootballGame.Other.Application.ViewModel.Match;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddFluentValidation();



builder.Services.AddTransient<IValidator<NewLeagueVm>, NewLeagueValidation>();
builder.Services.AddTransient<IValidator<NewSeasonVm>, NewSeasonValidation>();
builder.Services.AddTransient<IValidator<PlayAllMatchesOfSeasonVm>, PlayAllMatchesValidation>();

builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer("Server=.\\SQLEXPRESS;Database=FootballSim;Trusted_Connection=True;TrustServerCertificate=True;"));
builder.Services.AddApplication(); // Ensure this line is present

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();