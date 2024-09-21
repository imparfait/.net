namespace music_store.classes
{
    public class Sale
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int VinylRecordId { get; set; }
        public VinylRecord VinylRecord { get; set; }
        public DateTime SaleDate { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public int PromotionId { get; set; }
        public Promotion Promotion { get; set; }
    }
}
