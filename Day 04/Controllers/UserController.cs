using Day_03.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day_03.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(User user)
        {
            ViewBag.User = user;
            return View();
        }
    }
}
