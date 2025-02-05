using Microsoft.AspNetCore.Mvc;
using ParkingSystem.Data;
using ParkingSystem.Data.Models;

namespace ParkingSystem.Controllers
{
    public class CarController : Controller
    {
        private CarInMemoryDb carDb;

        public CarController(CarInMemoryDb db)
        {
            carDb = db;
        }

        public IActionResult Index()
        {
            return View(carDb.GetCars());
        }

        public IActionResult AddCar(Car car)
        {
            Car? carHere = carDb.GetCarById(car.PlateNumber);
            if (carHere != null)
            {
                TempData["Error"] = "Car with this plate number already exists!";
            }
            else
            {
                carDb.AddCar(car);
            }

            return RedirectToAction("Index");
        }

        public IActionResult DeleteCar(string plateNumber)
        {
            carDb.RemoveCar(plateNumber);
            return RedirectToAction("Index");
        }
    }
}
