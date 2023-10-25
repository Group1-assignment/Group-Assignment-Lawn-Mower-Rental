﻿using LawnMowerRentalAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMowerRentalAssignment.Services
{
    public static class UserInputHandler
    {
        private static RentalManager rentalManager = new RentalManager();
        

        public static void Initialize() {
            ProcessChoices();

        }


        private static void ProcessChoices() {
            while(true) {
                displayChoices();
                string? choice = Console.ReadLine();

                switch(choice) {
                    case "1":
                        Customer customer = GetCustomerDetails();
                        rentalManager.RegisterCustomer(customer);
                        break;

                    case "2":

                        ProcessRental();
                        break;

                    case "3":
                        LawnMowerModel[] models = (LawnMowerModel[])Enum.GetValues(typeof(LawnMowerModel)); //list lawnmower models
                        Console.WriteLine();
                        foreach(LawnMowerModel model in models) {
                            Console.WriteLine(model.ToString() + " " + rentalManager.GetLawnMowerStock(model));
                        }
                        break;

                    case "4":
                        DisplayRentals();
                        break;

                    case "5":
                        ProcessLawnmowerReturn();
                        break;


                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        public static void ProcessLawnmowerReturn() {
            List<Customer> rentingCustomers = rentalManager.GetRentingCustomers();

            if(rentingCustomers.Count > 0) {
                indexList(rentingCustomers);

                Customer customer = SelectListObject(rentingCustomers);

                indexList(customer.Rentals);

                Rental rental = SelectListObject(customer.Rentals);

                customer.ReturnRental(rental);
                rentalManager.SaveCustomerListToJson();

                Console.WriteLine("returned " + rental + ", Total Price: " + rental.TotalPrice());
            }
            else {
                Console.WriteLine("\nthere is currently no item in rental to return");
            }

        }

        public static T SelectListObject<T>(List<T> customers) {
            int choice;
            do {
                Console.Write("Select an option: ");
            } while(!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > customers.Count - 1);

            return customers[choice];
        }

        public static void DisplayRentals() {

            List<Customer> rentingCustomers = rentalManager.GetRentingCustomers();

            if(rentingCustomers.Count > 0) {
                foreach(Customer customer in rentingCustomers) {
                    Console.WriteLine($"Customer: {customer.Name}");
                    Console.WriteLine("Rentals:");

                    foreach(Rental rental in customer.Rentals) {
                        Console.WriteLine($"  - Item Type: {rental.RentedItem.Name}");
                        Console.WriteLine($"    Rental Start Date: {rental.RentalStartDate}");
                        Console.WriteLine($"    Days rented: " + rental.DaysPassed());
                        Console.WriteLine($"    Total price: {rental.TotalPrice()}");
                    }

                    Console.WriteLine(); // Add a blank line to separate customers
                }
            }
            else { Console.WriteLine("\nNo one is currently renting"); }
        }

        private static void DisplayStock(int itemStock) {
            Console.WriteLine("\nCurrent stock of LawnMowers available for renting: " + itemStock);
        }
        private static void ProcessRental()
        {
            Console.WriteLine("Is this an Electrical Electrical1:-1,Electrical2:-2, Petrol:-3 ");
            var inputValue = Convert.ToInt16(Console.ReadLine());

            var selectedModel = LawnMowerModel.Petrol;
            Rental rental = new Rental(new LawnMower(LawnMowerModel.Petrol));
            switch (inputValue)
            {
                case 1:
                    rental = new Rental(new LawnMower(LawnMowerModel.Electrical1));
                    selectedModel = LawnMowerModel.Electrical1;
                    break;
                case 2:
                    rental = new Rental(new LawnMower(LawnMowerModel.Electrical2));
                    selectedModel = LawnMowerModel.Electrical2;
                    break;
                case 3:
                    selectedModel = LawnMowerModel.Petrol;
                    rental = new Rental(new LawnMower(LawnMowerModel.Petrol));
                    break;
                default:
                    rental = new Rental(new LawnMower(LawnMowerModel.Petrol));
                    selectedModel = LawnMowerModel.Petrol; // Default to Petrol for invalid input
                    break;
            }


            int lawnMowerStock = rentalManager.GetLawnMowerStock(selectedModel);
            if (rentalManager.Customers.Count == 0)
                Console.WriteLine("Register User First");
            else if (lawnMowerStock <= 0)
            {
                Console.WriteLine("There are currently no available lawnmowers in stock");
            }
            else
            {
                DisplayStock(lawnMowerStock);
                List<Customer> customers = rentalManager.Customers;
                indexList(customers);
                int choice;
                do
                {
                    Console.Write("Who is renting? Select an option: ");
                } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > rentalManager.Customers.Count - 1);

                Customer customer = rentalManager.Customers[choice];
                customer.Rent(rental);
                string result = rental.RentedItem.GetEffectToString();

                Console.WriteLine($"new lawnmower rental added to customer:{customer.ToString()} {selectedModel} {result}");

                rentalManager.SaveCustomerListToJson();
            }
        }

        private static void displayChoices() {
            Console.WriteLine("\nLawn Mower Rental System");
            Console.WriteLine("1. Register Customer");
            Console.WriteLine("2. Rent Lawn Mower");
            Console.WriteLine("3. Check Available Lawn Mowers");
            Console.WriteLine("4. Display Customer Rentals");
            Console.WriteLine("5. Return Lawnmower");

            Console.Write("Select an option: ");

        }

        public static Customer GetCustomerDetails() {
            Console.Write("Customer Name: ");
            string? name = null;
            while(name == null)
                name = Console.ReadLine();

            int phoneNumber = ValidatePhoneNumber();

            CustomerType customerType = GetCustomerType();
            Customer customer = new Customer(name, phoneNumber, customerType);
            return customer;
        }
        public static CustomerType GetCustomerType() {

            string? input;
            CustomerType customerType;
            Console.WriteLine("enter professional or private customer: ");
            input = Console.ReadLine();
            input = input?.ToLower();
            if(input == "professional")
                customerType = CustomerType.Professional;
            else if(input == "private")
                customerType = CustomerType.Private;
            else {
                Console.WriteLine("wrong input, try again");
                return GetCustomerType();   //recursive method calling itself if the input is wrong
            }
            return customerType;
        }

        public static int ValidatePhoneNumber() {
            Console.Write("Customer Phone Number: ");
            int phoneNumber = 0;
            if(int.TryParse(Console.ReadLine(), out phoneNumber))
                return phoneNumber;
            return ValidatePhoneNumber();
        }

        public static void indexList<T>(List<T> items) {
            Console.WriteLine();
            for(int i = 0; i < items.Count; i++) {
                T item = items[i];
                Console.WriteLine(i + ". " + item);
            }
            Console.WriteLine();
        }
    }
}
