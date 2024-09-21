namespace music_store.classes
{
    public class Reservation
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int VinylRecordId { get; set; }
        public VinylRecord VinylRecord { get; set; }
        public DateTime ReservedDate { get; set; }
    }
}
