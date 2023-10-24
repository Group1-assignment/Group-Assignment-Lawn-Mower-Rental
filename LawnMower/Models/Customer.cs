using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMowerRentalAssignment
{
    public enum CustomerType
    {
        Private,
        Professional
    }
    public class Customer
    {

        //properties with getters only
        public string Name { get; }
        public int PhoneNumber { get; }
        public CustomerType CustomerType { get; }

        public List<Rental> Rentals { get; set; } = new List<Rental>();   //all the rentals of the customer

        //all fields are set in this constructor when creating the customer object
        public Customer(string name, int phoneNumber, CustomerType customerType)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            CustomerType = customerType;
        }

       

        public override string ToString()
        {
            return Name + ", " + PhoneNumber + ", " + CustomerType.ToString();
        }

        public void Rent(Rental rentalObject)
        {
            Rentals.Add(rentalObject);
        }

        public void ReturnRental(Rental rentalObject)
        {
            Rentals.Remove(rentalObject);
        }
    }



    class Basic : Customer
    {
        public Basic(string name, int phoneNumber, CustomerType customerType) : base(name, phoneNumber, customerType)
        {
        }
        public int MinDays { get; set; }
        // minimum  7 days betalning men kund får lämna tillbaka när som 

        public void PricePlan1(Rental rentalObject, int minDays = 7)
        {
            int actualDays = rentalObject.DaysPassed();
            if(actualDays < 7)
            {
                Console.WriteLine("Basic Coustumers are charged for at least 7 days");
                rentalObject.AdjustDays(minDays);
            }

            Rentals.Add(rentalObject);
        }



        // 25 % discount 
        public decimal Offer { get; set; }
        public DateTime EndDate { get; set; }

         bool coupon = false;

         decimal Discount(decimal offer, DateTime endDate)
        {
            Offer = offer;
            EndDate = endDate; // year.12,31
            coupon = false;

            // hur man håller koll på per år 
            // bool = true => enddate
            // overloading
            return 0;
        }
       
         bool EndOffer()
        {
            if (coupon = false)
            {
                DateTime date = DateTime.Now.Date;
                DateTime endDate = new DateTime(date.Year,12,31);


                return date > endDate;
            }

            return false; 
        }
       
    }

    class Prime : Customer
    {
        public decimal PointsPerDay { get; set; } // bonus p 

        public Prime(string name, int phoneNumber, CustomerType customerType) : base(name, phoneNumber, customerType)
        { }
        
      
        // går att använda samma typ som pris
            decimal Points()
        {


            return PointsPerDay;
        }







    }
}