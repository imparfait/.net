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

        public async Task<IActionResult> Create()
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var userEmail = User.FindFirstValue(ClaimTypes.Email);
                if (string.IsNullOrEmpty(userEmail))
                {
                    return BadRequest("Email not found for the user.");
                }

                await orderService.CreateAsync(userId, userEmail);

                return RedirectToAction(nameof(Index));
           }
    }
}
