using System;
namespace Group_1
{
	public class Rental
	{
        public int RentalDays { get; set; }
        public DateTime RentalTime { get; set; }

        public Rental(int rendalDays)
		{
            RentalDays = rendalDays;
            RentalTime = DateTime.Now;
        }
	}
}

