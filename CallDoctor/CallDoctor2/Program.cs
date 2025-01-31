using Services;
using ServiceConstracts;
using Entities;
using Microsoft.EntityFrameworkCore; 

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//Add Service into IoC container
builder.Services.AddScoped<ICitiesService, CitiesService>();
builder.Services.AddScoped<IDoctorsService, DoctorsService>();

builder.Services.AddDbContext<DoctorsDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
Rotativa.AspNetCore.RotativaConfiguration.Setup("wwwroot", wkhtmltopdfRelativePath: "Rotativa");
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.Run();

