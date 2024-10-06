using carList.Models;
using carShop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            return View(dbContext.Cars.ToList());
        }
        public IActionResult ConfirmDelete(int id)
        {
            var car = dbContext.Cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }
            dbContext.Cars.Remove(car);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }    
        public IActionResult Details(int id)
            {
                var car = dbContext.Cars.Find(id);
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
