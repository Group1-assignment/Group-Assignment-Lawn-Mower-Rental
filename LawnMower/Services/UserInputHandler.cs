using LawnMowerRentalAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                        RegisterCustomerFromConsole();
                        break;

                    case "2":

                        ProcessRental();
                        break;

                    case "3":
                        DisplayAllStock();
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

        private static void displayChoices() {
            Console.WriteLine("\nLawn Mower Rental System");
            Console.WriteLine("1. Register Customer");
            Console.WriteLine("2. Rent Lawn Mower");
            Console.WriteLine("3. Check Available Lawn Mowers");
            Console.WriteLine("4. Display Customer Rentals");
            Console.WriteLine("5. Return Lawnmower");

            Console.Write("Select an option: ");

        }

        private static void RegisterCustomerFromConsole() {
            Customer customer = GetCustomerDetails();
            if(rentalManager.PhoneNumberExists(customer.PhoneNumber)) {
                Console.WriteLine("Customer with phone number: " + customer.PhoneNumber + " is already registered");
            }
            else {
                rentalManager.RegisterCustomer(customer);
                Console.WriteLine("Registered customer: " + customer.ToString());
            }
        }

        public static Customer GetCustomerDetails() {
            Console.Write("Customer Name: ");
            string? name = null;
            while(name == null)
                name = Console.ReadLine();

            int phoneNumber = ValidatePhoneNumber();

            CustomerType customerType = GetCustomerType();

            Console.WriteLine("Do you want to become a prime Customer?  (yes/no)");
            string input = Console.ReadLine();
            bool primeCustomer = input == "yes";
            if(primeCustomer) {
                Console.WriteLine("You are now a Prime Customer");
            }
            else {
                Console.WriteLine("You are now a Basic customer");
            }

            Customer customer = new Customer(name, phoneNumber, customerType, primeCustomer);
            return customer;
        }

        public static int ValidatePhoneNumber() {
            Console.Write("Customer Phone Number: ");
            int phoneNumber = 0;
            if(int.TryParse(Console.ReadLine(), out phoneNumber))
                return phoneNumber;
            return ValidatePhoneNumber();
        }

        private static void ProcessRental() {

            List<LawnMowerModel> lawnmowermodels = GetListOfLawnMowerModels().ToList();
            int choice = ConsoleListSelector("Select a model ", lawnmowermodels);

            LawnMowerModel selectedModel = lawnmowermodels[choice];

            int lawnMowerStock = rentalManager.GetLawnMowerStock(selectedModel);
            if(rentalManager.Customers.Count == 0)
                Console.WriteLine("Register User First");
            else if(lawnMowerStock <= 0) {
                Console.WriteLine("There are currently no available lawnmowers of model " + selectedModel + " in stock");
            }
            else {
                DisplayStock(selectedModel);
                List<Customer> customers = rentalManager.Customers;

                choice = ConsoleListSelector("Who is renting? select an option: ", customers);

                Customer customer = rentalManager.Customers[choice];
                LawnMower lawnmower = new LawnMower(selectedModel);
                customer.Rent(lawnmower);
                string result = lawnmower.GetEffectToString();

                Console.WriteLine($"new {lawnmower.GetType().Name}, model: {lawnmower.Model} rental added to customer:{customer} {selectedModel} {result}");

                rentalManager.SaveCustomerListToJson();
            }
        }

        private static void DisplayAllStock() {
            LawnMowerModel[] models = GetListOfLawnMowerModels();
            Console.WriteLine();
            foreach(LawnMowerModel model in models) {
                Console.WriteLine(model.ToString() + " " + rentalManager.GetLawnMowerStock(model));
            }
        }

        private static LawnMowerModel[] GetListOfLawnMowerModels() {
            LawnMowerModel[] models = (LawnMowerModel[])Enum.GetValues(typeof(LawnMowerModel)); //list lawnmower models
            return models;
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
                    Console.WriteLine($"Customer: {customer}");
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

        private static void DisplayStock(LawnMowerModel model) {
            Console.WriteLine($"\nCurrent stock of LawnMowers, model {model} available for renting: " + rentalManager.GetLawnMowerStock(model));
        }

        private static int ConsoleListSelector<T>(string message, List<T> list) {
            indexList(list);
            int choice;
            do {
                Console.Write(message);
            } while(!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > rentalManager.Customers.Count - 1);
            return choice;
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
