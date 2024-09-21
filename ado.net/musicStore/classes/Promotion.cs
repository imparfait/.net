namespace Exam_.classes
{
    public class Promotion
    {
        public int Id { get; set; }
        public string Genre { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        //public int SaleId {  get; set; }
        public Sale Sale { get; set; }
    }
}
