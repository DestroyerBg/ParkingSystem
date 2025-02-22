using Microsoft.EntityFrameworkCore;
using ParkingSystem.Data.Models;

namespace ParkingSystem.Data
{
    public class CarDbContext : DbContext
    {
        public CarDbContext()
        {
            
        }
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options)
        {
            
        }

        public DbSet<Car> Cars { get; set; }
    }
}
