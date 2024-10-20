using System.ComponentModel.DataAnnotations;

namespace carShop
{
    public class Car
    {
        public int Id { get; set; }
        //[StringLength(50, ErrorMessage = "The car model must be between 2 and 50 characters.", MinimumLength = 2)]
        public string Model { get; set; }
        //[StringLength(20, ErrorMessage = "The color must be between 2 and 20 characters.", MinimumLength = 2)]
        public string Color { get; set; }
        //[Range(1886, 2024, ErrorMessage = "The car year must be between 1886 and the current year.")]
        public int Year { get; set; }
        //[StringLength(50, ErrorMessage = "The body type must be between 2 and 50 characters.", MinimumLength = 2)]
        public string BodyType { get; set; }
        public string? ImagePath { get; set; }
    }
}
