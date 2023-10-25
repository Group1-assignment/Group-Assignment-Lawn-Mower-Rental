using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMowerRentalAssignment
{
    class BasicCustomer:Customer
    {
        public BasicCustomer(string name, int phoneNumber, CustomerType customerType) : base(name, phoneNumber, customerType) {
        }
        public int MinDays { get; set; }
        // minimum  7 days betalning men kund får lämna tillbaka när som 



        // 25 % discount 
        public decimal Offer { get; set; }
        public DateTime EndDate { get; set; }

        bool coupon = false;

        decimal Discount(decimal offer, DateTime endDate) {
            Offer = offer;
            EndDate = endDate; // year.12,31
            coupon = false;

            // hur man håller koll på per år 
            // bool = true => enddate
            // overloading
            return 0;
        }

        bool EndOffer() {
            if(coupon = false) {
                DateTime date = DateTime.Now.Date;
                DateTime endDate = new DateTime(date.Year, 12, 31);


                return date > endDate;
            }

            return false;
        }

    }
}
