using Microsoft.EntityFrameworkCore;
using ParkingSystem.Data;

namespace ParkingSystem.Extensions
{
    public static  class WebApplicationExtensions
    {
        public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope serviceScope = app.ApplicationServices.CreateScope();

            CarDbContext dbContext = serviceScope
                .ServiceProvider
                .GetRequiredService<CarDbContext>();

            dbContext.Database.Migrate();

            return app;
        }
    }
}
