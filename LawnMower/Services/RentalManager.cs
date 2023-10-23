using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LawnMowerRentalAssignment
{
    public class RentalManager
    {
        private static string jsonPath = "C:\\Users\\thord\\Source\\Repos\\Group1-assignment\\Group-Assignment-Lawn-Mower-Rental\\LawnMower\\Services\\customers.json";
        private static List<Customer>? customers = new List<Customer>();

        public static List<RentalItem> RentalItems { get; } = new List<RentalItem>();

        public static List<Customer> Customers { get { return customers; } }

        public RentalManager() {
            RentalItems.Add(new RentalItem(7, 50, ItemType.Electrical1));
            RentalItems.Add(new RentalItem(7, 50, ItemType.Petrol));
            RentalItems.Add(new RentalItem(8, 50, ItemType.Electrical2));    //manually adding the Lawnmower item type with its max stock and price to a list of rentalItems
            InitializeCustomerList();

        }

        private void InitializeCustomerList() {
            if(File.Exists(jsonPath)) {
                string json = File.ReadAllText(jsonPath);

                try {
                    customers = JsonSerializer.Deserialize<List<Customer>>(json);
                    // If deserialization is successful, the customers list is populated.
                }
                catch(JsonException ex) {
                    // Handle the exception.
                    Console.WriteLine("Error deserializing customer data: " + ex.Message);
                    //initialize customers with an empty list.
                    customers = new List<Customer>();
                }
            }
            else {
                // If the JSON file doesn't exist, initialize customers with an empty list.
                customers = new List<Customer>();
            }
        }

        public List<Customer> GetRentingCustomers() {
            List<Customer> rentingCustomers = customers.Where(customer => customer.Rentals.Count > 0).ToList();

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

            string json = JsonSerializer.Serialize(customers, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonPath, json);
        }

        public Customer? GetCustomerByPhoneNumber(int phoneNumber) {
            Customer? customer = customers.FirstOrDefault(customer => customer.PhoneNumber == phoneNumber);

            return customer;
        }
        public static RentalItem? GetRentalItemById(ItemType type) {
            RentalItem? rentalItem = RentalItems.FirstOrDefault(rentalItem => rentalItem.ItemType == type);

            return rentalItem;
        }

        public bool PhoneNumberExists(int phoneNumber) {
            return GetCustomerByPhoneNumber(phoneNumber) != null;
        }

        public static int GetRentedCount(ItemType type) {
            int count = 0;
            foreach(Customer customer in customers) {
                foreach(Rental rental in customer.Rentals) {
                    if(rental.ItemType == type)
                        count++;
                }
            }
            return count;
        }
    }


}
