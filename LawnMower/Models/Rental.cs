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
        public int minimumDays { get; }

        public Rental(LawnMower itemToRent, int minimumDays) {
            RentalStartDate = DateTime.Now.Date;
            RentedItem = itemToRent;
            this.minimumDays = minimumDays;
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

        public decimal TotalPrice() {
            int daysPassed = DaysPassed();
            decimal pricePerDay = RentedItem.PricePerDay;
            if (minimumDays < daysPassed)
            {

                return pricePerDay * minimumDays;
            }
            else
            {

                decimal price = DaysPassed() * pricePerDay;
                return price;
            }


        }
        public decimal TotalPrice(int discount)
        {
            decimal offer = discount / 100;
            decimal result = TotalPrice() * offer;
            decimal newPrice = TotalPrice() - result;

            return newPrice;

        }

        public override string ToString() {
            return RentedItem.Name + ", StartDate: " + RentalStartDate + ", Days Passed: " + DaysPassed();
        }
    }


}
