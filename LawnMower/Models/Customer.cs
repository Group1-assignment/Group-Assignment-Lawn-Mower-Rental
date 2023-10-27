using LawnMowerRentalAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
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
        private DateTime endDate = SetEndDate();
        private int primeBonus;

        //properties with getters only
        public string Name { get; }
        public int PhoneNumber { get; }
        public CustomerType CustomerType { get; }

        public bool PrimeCustomer { get; set; }
        // discount 
        public bool UsedCoupon { get; set; } = false;
        public DateTime EndDate { get { return endDate; } }

        public int PrimeBonus { get { return primeBonus; } }

        public List<Rental> Rentals { get; set; } = new List<Rental>();   //all the rentals of the customer

        //all fields are set in this constructor when creating the customer object
        public Customer(string name, int phoneNumber, CustomerType customerType, bool primeCustomer) {
            Name = name;
            PhoneNumber = phoneNumber;
            CustomerType = customerType;
            PrimeCustomer = primeCustomer;
            primeBonus = 0;
        }
        //this constructor is only so the json deserialization should work properly
        [JsonConstructor]
        public Customer(string name, int phoneNumber, CustomerType customerType, int primeBonus, DateTime endDate, bool primeCustomer) :
            this(name, phoneNumber, customerType, primeCustomer) {
            this.primeBonus = primeBonus;
            this.endDate = endDate;
        }

        public override string ToString() {
            string prime = PrimeCustomer ? "Prime" : "Basic";
            return Name + ", " + PhoneNumber + ", " + CustomerType.ToString() + ", " + prime;
        }

        public virtual void Rent(LawnMower lawnmower) {
            int discount = ProcessDiscount();
            Rental rental = new Rental(lawnmower, GetMinDays(), discount);
            Rentals.Add(rental);
        }

        public void ReturnRental(Rental rentalObject) {
            if(PrimeCustomer)
                primeBonus += (int)rentalObject.TotalPrice();
            Rentals.Remove(rentalObject);
        }

        private int ProcessDiscount() {
            int discount;
            if(DateTime.Now > endDate) {
                UsedCoupon = false;
                SetEndDate();
            }

            if(UsedCoupon)
                discount = 0;
            else {
                UsedCoupon = true;
                discount = GetOffer();
            }
            return discount;
        }
        private int GetOffer() {
            if(!PrimeCustomer)
                return 25;
            else return 0;
        }
        private static DateTime SetEndDate() {
            return new DateTime(DateTime.Now.Year, 12, 31);
        }

        private int GetMinDays() {
            if(!PrimeCustomer)
                return 7;
            else
                return 0;
        }
    }
}
