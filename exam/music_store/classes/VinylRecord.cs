using System.ComponentModel.DataAnnotations;

namespace music_store.classes
{
    public class VinylRecord
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Artist { get; set; }
        public string Publisher { get; set; }
        public int TrackCount { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public bool IsReserved { get; set; }
        public bool IsOnSale { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
