using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMowerRentalAssignment {
    public class RentalManager {
        private List<Customer> customers = new List<Customer>();


        public void RegisterCustomer(string name, int phoneNumber, CustomerType customerType) {
            if(PhoneNumberExists(phoneNumber)) {
                Console.WriteLine("Customer with phone number: " + phoneNumber + " is already registered");
            }
            else {
                Customer customer = new Customer(name, phoneNumber, customerType);

                customers.Add(customer);
                Console.WriteLine("Registered customer: \n" + customer.ToString());
            }
        }

        public Customer? GetCustomerByPhoneNumber(int phoneNumber) {
            Customer ?customer = customers.FirstOrDefault(customer => customer.PhoneNumber == phoneNumber);

            return customer;
        }

        public bool PhoneNumberExists (int phoneNumber) {
            return GetCustomerByPhoneNumber(phoneNumber) != null;
        }
    }


}
