using BusinessLogic.Interfaces;
using carShop.Entities;
using carShop.Interfaces;

namespace BusinessLogic.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> orderRepo;
        private readonly ICartService cartService;

        public OrderService(IRepository<Order> orderRepo, ICartService cartService)
        {
            this.orderRepo = orderRepo;
            this.cartService = cartService;
        }
        public void Create(string userId)
        {
            var order = new Order()
            {
                Date = DateTime.Now,
                UserId = userId,
                Total = cartService.GetCars().Sum(c => c.Price)
            };
            orderRepo.Insert(order);
            orderRepo.Save();
        }

        public IEnumerable<Order> GetAll(string userId)
        {
            return orderRepo.Get(o => o.UserId == userId);
        }
    }
}