using Microsoft.EntityFrameworkCore;
using ParkingSystem.Data;
using ParkingSystem.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>();
string connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");
    builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<CarDbContext>(options => options.UseNpgsql(connectionString));
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<CarInMemoryDb>();
builder.Services.AddScoped<CarService>();
WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Car}/{action=Index}/{id?}");

app.Run();
