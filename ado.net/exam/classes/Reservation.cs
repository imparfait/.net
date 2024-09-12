using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam.classes
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
