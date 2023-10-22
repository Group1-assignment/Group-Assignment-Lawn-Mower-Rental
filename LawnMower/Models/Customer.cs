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

        public List<Rental> rentals { get; } = new List<Rental>();   //all the rentals of the customer

        //all fields are set in this constructor when creating the customer object
        public Customer(string name, int phoneNumber, CustomerType customerType) {
            Name = name;
            PhoneNumber = phoneNumber;
            CustomerType = customerType;
        }

        public override string ToString() {
            return Name + "\n" + PhoneNumber + "\n" + CustomerType.ToString();
        }

        public void NewRental(Rental rentalObject) {
            rentals.Add(rentalObject);
        }
    }
}
