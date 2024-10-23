using BusinessLogic.Interfaces;
using carShop;
using Microsoft.AspNetCore.Mvc;

namespace carList.Controllers
{
	public class CartController : Controller
	{
		private readonly ICartService cartService;

        public CartController(ICartService service)
        {
			this.cartService = service;
        }
		public IActionResult Index()
		{
			return View(cartService.GetProducts());
		}
		public IActionResult Add(int carId, string returnUrl)
		{
			cartService.Add(carId);
			return Redirect(returnUrl);
		}

		public IActionResult Remove(int carId, string returnUrl)
		{
			cartService.Remove(carId);
            return Redirect(returnUrl);
		}
	}
}
