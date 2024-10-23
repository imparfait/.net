using System.ComponentModel.DataAnnotations;

namespace carShop.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public string BodyType { get; set; }
        public string? ImagePath { get; set; }
        public ICollection<Cart> Carts { get; set; }
    }
}
