using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMowerRentalAssignment.Services {
    public static class UserInputHandler {

        private static void displayChoices() {
                Console.WriteLine("Lawn Mower Rental System");
                Console.WriteLine("1. Register Customer");
                Console.WriteLine("2. Rent Lawn Mower");
                Console.WriteLine("3. Check Available Lawn Mowers");
                Console.WriteLine("4. Display Customer Rentals");

                Console.Write("Select an option: ");

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

        public static Customer GetCustomerDetails(RentalManager rentalManager) {
            Console.Write("Customer Name: ");
            string? name = null;
            while(name == null)
                name = Console.ReadLine();


            CustomerType customerType = GetCustomerType();
            Customer customer = new Customer(name, phoneNumber, customerType);
            return customer;
        }

        public static void Initialize() {


            RentalManager rentalManager = new RentalManager();

            rentalManager.RegisterCustomer(GetCustomerDetails(rentalManager));

        }
        /*
            // Initialize lawn mowers with unique IDs.
            for(int i = 1; i <= 15; i++) {
                rentalApp.lawnMowers.Add(new LawnMower { MowerID = i, ModelName = "Lawn Mower " + i, Available = true });
            }

            while(true) {
                displayChoices();
                string? choice = Console.ReadLine();

                switch(choice) {
                    case "1":
                        break;

                    case "2":
                        Console.Write("Customer ID: ");
                        if(int.TryParse(Console.ReadLine(), out int customerID)) {
                            Console.Write("Lawn Mower ID enter (1-15): ");
                            if(int.TryParse(Console.ReadLine(), out int mowerID)) {
                                Console.Write("Start Date (YYYY-MM-DD): ");
                                if(DateTime.TryParse(Console.ReadLine(), out DateTime startDate)) {
                                    Console.Write("Rental Days: ");
                                    if(int.TryParse(Console.ReadLine(), out int rentalDays)) {
                                        rentalApp.RentLawnMower(customerID, mowerID, startDate, rentalDays);
                                    }
                                    else {
                                        Console.WriteLine("Invalid rental days.");
                                    }
                                }
                                else {
                                    Console.WriteLine("Invalid start date.");
                                }
                            }
                            else {
                                Console.WriteLine("Invalid lawn mower ID.");
                            }
                        }
                        else {
                            Console.WriteLine("Invalid customer ID.");
                        }
                        //  rentalApp.RentLawnMower();
                        break;

                    case "3":

                        Console.WriteLine("Check available lawn mowers to take on rent :");
                        rentalApp.CheckAvailableLawnMower();
                        break;

                    case "4":
                        Console.WriteLine("List of customers holding lawn mowers :");
                        rentalApp.DisplayCustomerRentals();
                        break;


                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }*/
    }
}
