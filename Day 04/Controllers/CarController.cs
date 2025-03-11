using Day_03.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day_03.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View(CarList.Cars);
        }

        [Route("/Car/{id:int}")]
        public IActionResult Details(int id)
        {
            return View(CarList.Cars.SingleOrDefault(car => car.ID == id));
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Car car)
        {
            CarList.Cars.Add(car);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            return View(CarList.Cars.SingleOrDefault(car => car.ID == id));
        }

        [HttpPost]
        public IActionResult Update(Car car)
        {
            var updatedCar = CarList.Cars.SingleOrDefault(ca => ca.ID == car.ID);
            updatedCar.Model = car.Model;
            updatedCar.Color = car.Color;
            updatedCar.Manfacture = car.Manfacture;

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var car = CarList.Cars.SingleOrDefault(c => c.ID == id);
            CarList.Cars.Remove(car);

            return RedirectToAction("Index");
        }
    }
}
