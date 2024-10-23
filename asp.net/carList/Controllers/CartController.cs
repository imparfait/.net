using BusinessLogic.Interfaces;
using carShop;
using Microsoft.AspNetCore.Mvc;

namespace carList.Controllers
{
	public class CartController : Controller
	{
		private readonly ICartService cartService;
       // private readonly ICarService carService;
        private readonly CarContext context;

        public CartController(ICartService service, CarContext context)//, ICarService carService
        {
			this.cartService = service;
            this.context = context;
		//	this.carService = carService;
        }
		public IActionResult Index()
		{
			return View(cartService.GetProducts());
		}
		public IActionResult Add(int carId, string returnUrl)
		{
			cartService.Add(carId);
		//	context.Cars.Add(carService.GetById(carId));
			//context.SaveChanges();
			return Redirect(returnUrl);
		}

		public IActionResult Remove(int carId, string returnUrl)
		{
			cartService.Remove(carId);
            //context.Cars.Add(carService.GetById(carId));
           // context.SaveChanges();
            return Redirect(returnUrl);
		}
	}
}
