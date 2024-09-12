using System.ComponentModel.DataAnnotations;

namespace Exam_.classes
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public decimal TotalSpent { get; set; }
        public decimal Discount { get; set; }
    }
}
