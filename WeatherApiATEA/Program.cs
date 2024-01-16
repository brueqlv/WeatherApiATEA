using Microsoft.EntityFrameworkCore;
using WeatherApiATEA.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<WeatherDBContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("WeatherDatabase");

    options.UseSqlServer(connectionString);
}, ServiceLifetime.Scoped);

builder.Services.AddTransient<WeatherDataRetrievalService>();

var app = builder.Build();

app.UseExceptionHandler("/Weather/Error");
app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Weather}/{action=Index}/{id?}");

app.Run();
