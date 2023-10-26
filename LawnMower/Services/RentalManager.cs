using LawnMowerRentalAssignment;
using LawnMowerRentalAssignment.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LawnMowerRentalAssignment
{
    public class RentalManager
    {
        private static string jsonPath = "/Users/bledonqyqalla/Desktop/coding/Group-Assignment-Lawn-Mower-Rental/LawnMower/Services/customers.json";
        private List<Customer>? customers = new List<Customer>();

        public List<Customer> Customers { get { return customers; } }

        public RentalManager() {
          // InitializeCustomerList();

        }
        

        private void InitializeCustomerList()
        {
            if (File.Exists(jsonPath))
            {
                string json = File.ReadAllText(jsonPath);

                try
                {

                    customers = JsonSerializer.Deserialize<List<Customer>>(json);
                }
                catch (JsonException ex)
                {
                    // Handle the exception.
                    Console.WriteLine("Error deserializing customer data: " + ex.Message);
                    //initialize customers with an empty list.
                    customers = new List<Customer>();
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                // If the JSON file doesn't exist, initialize customers with an empty list.
                customers = new List<Customer>();
            }
        }

        public List<Customer> GetRentingCustomers() {
            List<Customer> rentingCustomers = customers.Where(customer => customer.Rentals.Count > 0).ToList();

            foreach(Customer customer in rentingCustomers)
                Console.WriteLine(customer.ToString());

            return rentingCustomers;
        }


        public void RegisterCustomer(Customer customer) {

            if(PhoneNumberExists(customer.PhoneNumber)) {
                Console.WriteLine("Customer with phone number: " + customer.PhoneNumber + " is already registered");
            }
            else {
                customers.Add(customer);
                Console.WriteLine("Registered customer: " + customer.ToString());
                SaveCustomerListToJson();
            }
        }

        public void SaveCustomerListToJson() {


            var options = new JsonSerializerOptions {
                WriteIndented = true // Optional: Makes the JSON output human-readable
            };

            string json = JsonSerializer.Serialize(customers, options);
            File.WriteAllText(jsonPath, json);
        }


        public Customer? GetCustomerByPhoneNumber(int phoneNumber) {
            Customer? customer = customers.FirstOrDefault(customer => customer.PhoneNumber == phoneNumber);

            return customer;
        }
        /*public static RentalItem? GetRentalItemById(LawnMowerModel type) {
            RentalItem? rentalItem = RentalItems.FirstOrDefault(rentalItem => rentalItem.ItemType == type);

            return rentalItem;
        }*/

        public bool PhoneNumberExists(int phoneNumber) {
            return GetCustomerByPhoneNumber(phoneNumber) != null;
        }

        public static int GetRentedCount(RentalItem rentalItem) {
            int count = 0;
            foreach(Customer customer in new RentalManager().customers) {
                foreach(Rental rental in customer.Rentals) {
                    if(rentalItem.GetType() == rental.RentedItem.GetType())
                        count++;
                }
            }
            return count;
        }
        public static int GetLawnMowerCount(LawnMowerModel lawnMowerModel) {
            int count = 0;
            foreach(Customer customer in new RentalManager().customers) {
                foreach(Rental rental in customer.Rentals) {
                    if(lawnMowerModel == rental.RentedItem.Model)
                        count++;
                }
            }
            return count;
        }

        public int GetLawnMowerStock(LawnMowerModel lawnMowerModel) {
            int stock = LawnMower.GetMaxStock(lawnMowerModel) - GetLawnMowerCount(lawnMowerModel);
            return stock;

        }
    }
}
