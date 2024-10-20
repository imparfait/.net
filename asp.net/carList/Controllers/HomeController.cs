using carList.Models;
using carShop;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace carList.Controllers
{
    public class HomeController : Controller
    {
        private readonly CarContext dbContext;

        public HomeController(CarContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            var cars = dbContext.Cars.ToList();
            return View(cars);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
