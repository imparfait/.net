using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_.classes
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
    }
}
