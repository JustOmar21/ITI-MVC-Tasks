using Microsoft.AspNetCore.Mvc;

namespace Day_02.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(string Name, string Picture, double Price, string Description)
        {
            ViewBag.Name = Name;
            ViewBag.Picture = Picture;
            ViewBag.Price = Price;
            ViewBag.Description = Description;
            return View();
        }
    }
}
