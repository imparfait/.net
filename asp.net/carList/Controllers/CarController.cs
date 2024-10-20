using carShop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace carList.Controllers
{
    public class CarController : Controller
    {
        private readonly CarContext dbContext;

        public CarController(CarContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            var cars = dbContext.Cars.ToList();
            return View(cars);
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
        public IActionResult Create(Car car)
        {

            if (!ModelState.IsValid)
            {
                return View(car);
            }
            dbContext.Cars.Add(car);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var car = dbContext.Cars.Find(id);
            if (car == null) return NotFound();
            return View(car);
        }
        [HttpPost]
        public IActionResult Edit(Car car)
        {
            if (!ModelState.IsValid)
            {
                return View(car);
            }
            dbContext.Cars.Update(car);
            dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
