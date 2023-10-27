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
        public int Offer { get; }

        public Rental(LawnMower rentedItem, int minimumDays, int offer) {
            RentalStartDate = DateTime.Now.Date;
            RentedItem = rentedItem;
            this.minimumDays = minimumDays;
            Offer = offer;
        }
        [JsonConstructor]
        public Rental(LawnMower rentedItem, int minimumDays, DateTime rentalStartDate, int offer) : this(rentedItem, minimumDays, offer) {
            RentalStartDate = rentalStartDate;
        }

        public int DaysPassed() {
            DateTime currentDate = DateTime.Now;
            TimeSpan timePassed = currentDate - RentalStartDate;
            int daysPassed = timePassed.Days;
            return daysPassed;

        }

        public decimal TotalPrice() {
            decimal totalPrice;
            int daysPassed = DaysPassed();
            if(daysPassed == 0)
                daysPassed = 1;
            decimal pricePerDay = RentedItem.PricePerDay;
            if(minimumDays > daysPassed) {

                totalPrice = pricePerDay * minimumDays;
            }
            else {
                totalPrice = daysPassed * pricePerDay;
            }
            decimal offer;
            if(Offer > 0) {
                offer = Offer / 100;
                decimal discountMoney = totalPrice * offer;
                totalPrice -= discountMoney;
            }
            return totalPrice;

        }

        public override string ToString() {
            return RentedItem.Name + ", StartDate: " + RentalStartDate + ", Days Passed: " + DaysPassed();
        }
    }


}
