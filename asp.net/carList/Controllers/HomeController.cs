using carList.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace carList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private static List<Car> cars = new List<Car>
    {
        new Car { Id = 1, Model = "Tesla Model S", Color = "Black", Year = 2022, BodyType = "Sedan" },
        new Car { Id = 2, Model = "Ford Mustang", Color = "Red", Year = 1967, BodyType = "Coupe" }
    };
        public IActionResult Index()
        {
            return View(cars);
        }
        public IActionResult ConfirmDelete(int id)
        {
            var car = cars.Find(c => c.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            cars.Remove(car);
            return RedirectToAction("Index");
        }    
        public IActionResult Details(int id)
            {
                var car = cars.Find(c => c.Id == id);
                if (car == null)
                {
                    return NotFound();
                }
                return View(car);
            }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
