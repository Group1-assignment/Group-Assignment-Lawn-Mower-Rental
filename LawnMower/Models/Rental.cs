using LawnMowerRentalAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LawnMowerRentalAssignment
{
    public class Rental
    {
        public DateTime RentalStartDate { get; }
        public LawnMower RentedItem { get; }

        public Rental(LawnMower itemToRent) {
            RentalStartDate = DateTime.Now.Date;
            RentedItem = itemToRent;
        }
        [JsonConstructor]
        public Rental(LawnMower rentedItem, DateTime rentalStartDate) {
            RentedItem = rentedItem;
            RentalStartDate = rentalStartDate;
        }

        public int DaysPassed() {
            DateTime currentDate = DateTime.Now;
            TimeSpan timePassed = currentDate - RentalStartDate;
            int daysPassed = timePassed.Days;
            return daysPassed;
        }
        // metod för minst 7 dagar 
        public void AdjustDays(int minDays)
        {
            int actualDays = DaysPassed();
            if (actualDays < minDays)
            {
                RentalStartDate = RentalStartDate.AddDays(minDays - actualDays);
                
            }
        }



        public decimal TotalPrice() {

            if (true)
            {
                
            }
            else 
            {
                decimal pricePerDay = RentedItem.PricePerDay;
                decimal price = DaysPassed() * pricePerDay;
                return price;

            }
            
        }

        public decimal TotalPoints()
        {
            decimal pointsPerDay = RentedItem.PricePerDay;
            decimal points = DaysPassed() * pointsPerDay;
            return pointsPerDay;
        }

        public override string ToString() {
            return RentedItem.Name + ", StartDate: " + RentalStartDate + ", Days Passed: " + DaysPassed();
        }
    }


}
