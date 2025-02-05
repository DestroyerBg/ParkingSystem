using ParkingSystem.Data;
using ParkingSystem.Data.Models;

namespace ParkingSystem.Tests
{
    public class CarInMemoryDbTests
    {
        private CarInMemoryDb carDb;

        [SetUp]
        public void Setup()
        {
            carDb = new CarInMemoryDb();
        }

        [Test]
        public void Test_Add_Car_Should_Add_Car_Correctly()
        {
            Car car = new Car()
            {
                CarMake = "BMW",
                PlateNumber = "CA1234CA"
            };

            carDb.AddCar(car);

            Assert.AreEqual(1, carDb.GetCars().Count);

            Car carFromDb = carDb.GetCarById("CA1234CA");

            Assert.IsNotNull(carFromDb);
            Assert.AreEqual("BMW", carFromDb.CarMake);
        }

        [Test]
        public void Test_Remove_Car_Should_Remove_Car_Correctly()
        {
            Car car = new Car()
            {
                CarMake = "BMW",
                PlateNumber = "CA1234CA"
            };

            carDb.AddCar(car);

            Assert.AreEqual(1, carDb.GetCars().Count);

            carDb.RemoveCar("CA1234CA");

            Assert.AreEqual(0, carDb.GetCars().Count);
        }

        [Test]
        public void Test_Get_Cars_Method_Should_Return_All_Cars()
        {
            Car car1 = new Car()
            {
                CarMake = "BMW",
                PlateNumber = "CA1234CA"
            };

            carDb.AddCar(car1);

            Car car2 = new Car()
            {
                CarMake = "Audi",
                PlateNumber = "CA4321CA"
            };

            carDb.AddCar(car2);

            Assert.IsNotNull(carDb.GetCars());
            Assert.AreEqual(2, carDb.GetCars().Count);
        }
       
    }
}
