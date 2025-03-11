using Day_03.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day_03.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Cars = CarList.Cars;
            return View();
        }

        [Route("/Car/{id:int}")]
        public IActionResult Details(int id)
        {
            ViewBag.Car = CarList.Cars.SingleOrDefault(car => car.ID == id);
            return View();
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
            ViewBag.Car = CarList.Cars.SingleOrDefault(car => car.ID == id);
            return View();
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
