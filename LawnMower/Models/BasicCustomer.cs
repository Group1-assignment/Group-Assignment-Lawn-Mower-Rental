using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LawnMowerRentalAssignment.Models;

namespace LawnMowerRentalAssignment
{
    class BasicCustomer:Customer
    {
        public BasicCustomer(string name, int phoneNumber, CustomerType customerType) : base(name, phoneNumber, customerType) {
        }

        // minimum  7 days 
        public override void Rent(LawnMower lawnmower)
        {
            Rental rental = new Rental(lawnmower, 7);
            Rentals.Add(rental);
        }


        // 25 % discount 
        public decimal Offer { get; set; }
        public DateTime EndDate { get; set; }
        public bool coupon { get; set; }

         

        decimal Discount(decimal offer, DateTime endDate) {
            Offer = offer;
            EndDate = endDate; // year.12,31
            coupon = false;

            // hur man håller koll på per år 
            // bool = true => enddate
            // overloading


            return offer ;
        }


        bool HasOffer() { // använd eller inte 
            if(coupon == false) { 
                DateTime date = DateTime.Now.Date;
                DateTime endDate = new DateTime(date.Year, 12, 31);


                return date > endDate;
            }

            return false;

        }

       
    }
}
