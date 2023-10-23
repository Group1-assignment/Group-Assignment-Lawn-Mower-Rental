﻿using System;
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
        private List<Customer> customers = new List<Customer>();
        private List<RentalItem> RentalItems { get; } = new List<RentalItem>();

        public List<Customer> Customers { get { return customers; } }

        public RentalManager() {
            RentalItems.Add(new RentalItem(15, 50, ItemType.LawnMower));    //manually adding the Lawnmower item type with its max stock and price to a list of rentalItems
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
        public RentalItem? GetRentalItemById(ItemType type) {
            RentalItem? rentalItem = RentalItems.FirstOrDefault(rentalItem => rentalItem.Id == type);

            return rentalItem;
        }

        public bool PhoneNumberExists(int phoneNumber) {
            return GetCustomerByPhoneNumber(phoneNumber) != null;
        }

        public int GetRentedCount(ItemType type) {
            int count = 0;
            foreach(Customer customer in customers) {
                foreach(Rental rental in customer.Rentals) {
                    if(rental.ItemType == type)
                        count++;
                }
            }
            return count;
        }
        public int GetItemStock(ItemType type) {
            RentalItem? rentalItem = GetRentalItemById(type);
            int stock = rentalItem.MaxStock - GetRentedCount(type);
            return stock;
        }

        public decimal TotalPrice(Rental rental) {
            decimal pricePerDay = GetRentalItemById(rental.ItemType).PricePerDay;
            decimal price = rental.DaysPassed() * pricePerDay;
            return price;
        }
    }


}