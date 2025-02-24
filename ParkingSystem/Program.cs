using Microsoft.EntityFrameworkCore;
using Npgsql;
using ParkingSystem.Data;
using ParkingSystem.Extensions;
using ParkingSystem.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>();
string connectionString = Environment.GetEnvironmentVariable("ConnectionStrings_DefaultConnection") ??
    builder.Configuration.GetConnectionString("DefaultConnection");

connectionString = connectionString.Trim('"');

NpgsqlConnectionStringBuilder connectionStrinbulder = new NpgsqlConnectionStringBuilder(connectionString)
{
    SslMode = SslMode.Prefer,
    TrustServerCertificate = true,
};

connectionString = connectionStrinbulder.ConnectionString;

Console.WriteLine(connectionString);

builder.Services.AddDbContext<CarDbContext>(options => options.UseNpgsql(connectionString));
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<CarService>();
builder.Services.AddSingleton<CarInMemoryDb>();
WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.ApplyMigrations();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Car}/{action=Index}/{id?}");

app.Run();
