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
        public ItemType ItemType { get; }

        public Rental(ItemType itemType) {
            RentalStartDate = DateTime.Now.Date;
            ItemType = itemType;
        }
        [JsonConstructor]
        public Rental(ItemType itemType, DateTime rentalStartDate) {
            ItemType = itemType;
            RentalStartDate = rentalStartDate;
        }

        public int DaysPassed() {
            DateTime currentDate = DateTime.Now;
            TimeSpan timePassed = currentDate - RentalStartDate;
            int daysPassed = timePassed.Days;
            return daysPassed;
        }

        public override string ToString() {
            return ItemType.ToString() + ", StartDate: " + RentalStartDate + ", Days Passed: " + DaysPassed();
        }
    }


}
