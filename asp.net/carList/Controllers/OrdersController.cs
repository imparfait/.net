using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace carList.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService orderService;
        private string GetUseId() => User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        public IActionResult Index()
        {
            return View(orderService.GetAll(GetUseId()));
        }

        public IActionResult Create()
        {
            orderService.Create(GetUseId());

            return RedirectToAction(nameof(Index));
        }
    }
}
