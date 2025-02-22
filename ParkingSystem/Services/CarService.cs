using Microsoft.EntityFrameworkCore;
using ParkingSystem.Data;
using ParkingSystem.Data.Models;

namespace ParkingSystem.Services
{
    public class CarService
    {
        private readonly CarDbContext context;

        public CarService(CarDbContext _context)
        {
            context = _context;
        }

        public async Task AddCar(Car car)
        {
            context.Cars.Add(new Car()
            {
                Id = Guid.NewGuid(),
                CarMake = car.CarMake,
                PlateNumber = car.PlateNumber
            });

        await context.SaveChangesAsync();
        }

        public async Task<IList<Car>> GetCars()
        {
            return context.Cars
                .OrderBy(c => c.CarMake)
                .ToList();
        }

        public async Task<Car> GetCarById(string id)
        {
            return await context.Cars.FirstOrDefaultAsync(c => c.Id == Guid.Parse(id));
        }

        public async Task RemoveCar(string plateNumber)
        {
            context.Cars.Remove(await GetCarById(plateNumber));
            await context.SaveChangesAsync();
        }
    }
}
