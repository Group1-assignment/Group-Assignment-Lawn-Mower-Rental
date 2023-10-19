using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMowerRentalAssignment {
    public enum CustomerType {
        Private,
        Professional
    }
    public class Customer {

        //Private fields. these along with getter properties and no setters
        //will ensure that these fields can't be changed outside of the class after being created,
        //while still being accessable for reading the values
        private string name;
        private int phoneNumber;
        private CustomerType customerType;

        //properties with getters only
        public string Name {
            get{
                return name;
            }
        }
        public int PhoneNumber {
            get {
                return phoneNumber;
            }
        }

        public List<Rental> rentals = new List<Rental>();   //all the rentals of the customer
        
        //all fields are set in this constructor when creating the customer object
        public Customer(string name, int phoneNumber, CustomerType customerType) {
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.customerType = customerType;
        }
    }
}
