using BusinessLogic.Interfaces;
using carShop.Entities;
using carShop.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Text;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace BusinessLogic.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> orderRepo;
        private readonly ICartService cartService;
        private readonly IEmailSender emailSender;

        public OrderService(IRepository<Order> orderRepo, ICartService cartService, IEmailSender emailSender)
        {
            this.orderRepo = orderRepo;
            this.cartService = cartService;
            this.emailSender = emailSender;
        }
        public async Task CreateAsync(string userId, string userEmail)
        {
            var cars = cartService.GetCars();
            var order = new Order()
            {
                Date = DateTime.Now,
                UserId = userId,
                Total = cartService.GetCars().Sum(c => c.Price)
            };
            orderRepo.Insert(order);
            orderRepo.Save();
           
            var emailBody = GenerateOrderEmailBody(order, cars);
            await emailSender.SendEmailAsync(userEmail, "Order Confirmation", emailBody);
            cartService.ClearCart();
        }
        private string GenerateOrderEmailBody(Order order, IEnumerable<Car> cars)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<h1>Order Confirmation</h1>");
            sb.AppendLine($"<p>Order ID: {order.Id}</p>");
            sb.AppendLine($"<p>Order Date: {order.Date}</p>");
            sb.AppendLine($"<p>Total: {order.Total:C}</p>");
            sb.AppendLine("<ul>");
            foreach (var car in cars)
            {
                sb.AppendLine($"<li>{car.Model} - {car.Price:C}</li>");
            }
            sb.AppendLine("</ul>");
            return sb.ToString();
        }
        public IEnumerable<Order> GetAll(string userId)
        {
            return orderRepo.Get(o => o.UserId == userId);
        }
    }
}