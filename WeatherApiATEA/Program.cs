using Microsoft.EntityFrameworkCore;
using WeatherApiATEA.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<WeatherDBContext>(options =>
{
    options.UseSqlServer("Server=GundarsPC;Database=Weather;Trusted_Connection=True;");
}, ServiceLifetime.Scoped);

builder.Services.AddHttpClient();
builder.Services.AddTransient<WeatherRepository>();
builder.Services.AddTransient<WeatherService>();
builder.Services.AddTransient<WeatherDataRetrievalService>();

builder.Services.AddHostedService<DataInitializationService>();


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
