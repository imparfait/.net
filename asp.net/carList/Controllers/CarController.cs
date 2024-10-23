using carShop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.Interfaces;


namespace carList.Controllers
{
    public class CarController : Controller
    {
		private readonly ICarService service;

		public CarController(ICarService service)
		{
			this.service = service;
		}

		public IActionResult Index()
        {
            var cars = service.GetAll();
            return View(cars);
        }
        public IActionResult ConfirmDelete(int id)
        {
			service.Delete(id);
			return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int id)
        {
			if (id < 0) { return BadRequest(); }

			var car = service.GetById(id);

			if (car == null) { return NotFound(); }
			
			return View(car);
        }
        public IActionResult Create(Car car)
        {

            if (!ModelState.IsValid)
            {
                return View(car);
            }
			service.Create(car);
			return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var car = service.GetById(id);
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
			service.Edit(car);
			return RedirectToAction(nameof(Index));
        }
    }
}
