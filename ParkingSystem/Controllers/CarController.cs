using Microsoft.AspNetCore.Mvc;
using ParkingSystem.Data;
using ParkingSystem.Data.Models;
using ParkingSystem.Services;

namespace ParkingSystem.Controllers
{
    public class CarController : Controller
    {
       private readonly CarService carService;

        public CarController(CarService _carService)
        {
            carService = _carService;
        }

        public async  Task<IActionResult> Index()
        {
            return View(await carService.GetCars());
        }

        public async  Task<IActionResult> AddCar(Car car)
        {
            await carService.AddCar(car);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCar(string id)
        {
            await carService.RemoveCar(id);
            return RedirectToAction("Index");
        }
    }
}
