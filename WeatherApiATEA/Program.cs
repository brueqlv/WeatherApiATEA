
using Microsoft.EntityFrameworkCore;
using WeatherApiATEA.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<WeatherDBContext>(options =>
{
    options.UseSqlServer("Server=GundarsPC;Database=Weather;Trusted_Connection=True;");
}, ServiceLifetime.Scoped);

builder.Services.AddHttpClient();
builder.Services.AddTransient<WeatherRepository>();
builder.Services.AddTransient<WeatherService>();

builder.Services.AddScoped<WeatherUpdateService>();

builder.Services.AddHostedService<DataInitializationService>();

var app = builder.Build();

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
