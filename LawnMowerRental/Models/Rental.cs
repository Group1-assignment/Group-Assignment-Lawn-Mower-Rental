using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMowerRental.Models
{
    public class Rental
    {
        public Customer Customer { get; set; }
        public LawnMower Mower { get; set; }
        public DateTime StartDate { get; set; }
        public int RentalDays { get; set; }
    }
}
