using ParkingSystem.Data.Models;

namespace ParkingSystem.Data
{
    public class CarInMemoryDb
    {
        private IList<Car> cars;

        public CarInMemoryDb()
        {
            cars = new List<Car>();
        }

        public void AddCar(Car car)
        {
            cars.Add(car);
        }

        public IList<Car> GetCars()
        {
            return cars;
        }

        public Car GetCarById(string plateNumber)
        {
            return cars.FirstOrDefault(c => c.PlateNumber == plateNumber);
        }

        public void RemoveCar(string plateNumber)
        {
            cars.Remove(GetCarById(plateNumber));
        }
    }
}

