using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.Interfaces;
using carShop.Entities;
using Microsoft.AspNetCore.Authorization;


namespace carList.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CarController : Controller
    {
		private readonly ICarService service;

		public CarController(ICarService service)
		{
			this.service = service;
		}
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(service.GetAll());
        }
        public IActionResult ConfirmDelete(int id)
        {
			service.Delete(id);
			return RedirectToAction(nameof(Index));
        }
        [AllowAnonymous]
        public IActionResult Details(int id, string returnUrl = null)
        {
			if (id < 0) { return BadRequest(); }

			var car = service.GetById(id);

			if (car == null) { return NotFound(); }
			ViewBag.ReturnUrl = returnUrl;
			return View(car);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
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
