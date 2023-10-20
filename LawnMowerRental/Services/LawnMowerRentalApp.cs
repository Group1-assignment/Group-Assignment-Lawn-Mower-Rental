using LawnMowerRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMowerRental.Services
{
    public class LawnMowerRentalApp
    {
        static List<Customer> customers = new List<Customer>();
        public List<LawnMower> lawnMowers = new List<LawnMower>();
        private List<Rental> rentals = new List<Rental>();
        private int nextCustomerID = 1;
        public void RegisterCustomer(string name, string phoneNumber)
        {
            int existingCustomerID = GetCustomerIDByPhoneNumber(phoneNumber);
            if (existingCustomerID != -1)
            {
                Console.WriteLine("Customer already registered with ID: " + existingCustomerID);
                return;
            }

            var customer = new Customer
            {
                CustomerID = nextCustomerID,
                Name = name,
                PhoneNumber = phoneNumber,
                Rentals = new List<Rental>()
            };

            customers.Add(customer);
            Console.WriteLine("Customer registered with ID: " + nextCustomerID);
            nextCustomerID++;
        }

        public void RentLawnMower(int customerID, int mowerID, DateTime startDate, int rentalDays)
        {
            Customer customer = GetCustomerByID(customerID);
            if (customer == null)
            {
                Console.WriteLine("Customer with ID " + customerID + " is not registered.");
                return;
            }
            else
            {
                LawnMower mower = GetLawnMowerByID(mowerID);
                if (mower == null || !mower.Available)
                {
                    Console.WriteLine("Lawn mower " + mowerID + " is not available for rent.Please check available and book it agian.");
                    return;
                }

                Rental rental = new Rental
                {
                    Customer = customer,
                    Mower = mower,
                    StartDate = startDate,
                    RentalDays = rentalDays
                };

                rentals.Add(rental);
                mower.Available = false;
                customer.Rentals.Add(rental);
                Console.WriteLine($" Customer {customer.Name} rented LawnMower {mower.MowerID} on {startDate} for {rentalDays} days ");


            }


        }

        //public void RentLawnMower()
        //{
        //    Console.Write("Enter customer ID: ");
        //    int customerID = int.Parse(Console.ReadLine());
        //    Customer customer = customers.Find(c => c.CustomerID == customerID);
        //    if (customer == null)
        //    {
        //        Console.WriteLine("Invalid customer ID. Please register the customer first.");
        //        return;
        //    }

        //    Console.WriteLine("Available Lawn Mowers:");
        //    int index = 1;
        //    foreach (LawnMower mower in lawnMowers)
        //    {
        //        if (mower.Available)
        //        {
        //            Console.WriteLine($"{index}. Model: {mower.ModelName}, ID: {mower.MowerID}");
        //            index++;
        //        }
        //    }
        //    Console.Write("Enter lawn mower number to rent: ");
        //    int mowerNumber = int.Parse(Console.ReadLine());
        //    if (mowerNumber >= 0 && mowerNumber < lawnMowers.Count && lawnMowers[mowerNumber].Available)
        //    {
        //        LawnMower selectedMower = lawnMowers[mowerNumber];
        //        selectedMower.Available = false;
        //        Console.WriteLine($"Rental of Lawn Mower {mowerNumber }confirmed to {customerID} {customer.Name}");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Invalid lawn mower number or the mower is not available for rental.");
        //    }

        //    Console.Write("Start Date (YYYY-MM-DD): ");
        //    if (DateTime.TryParse(Console.ReadLine(), out DateTime startDate))
        //    {
        //        return;
        //    }
        //    else
        //    {
        //        Console.WriteLine("Invalid start date.");
        //    }
        //        Console.Write("Rental Days: ");
        //        if (int.TryParse(Console.ReadLine(), out int rentalDays))
        //        {
        //            return;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Invalid rental days.");
        //        }



        //}
        public void DisplayCustomerRentals()
        {

            foreach (var rental1 in rentals)
            {
                Console.WriteLine("Customer name:" + rental1.Customer.Name);
                Console.WriteLine("Lawn Mower Id: " +rental1.Mower.MowerID );
                Console.WriteLine("Start Date: " + rental1.StartDate.ToShortDateString());
                Console.WriteLine("Rental Days: " + rental1.RentalDays);
              Console.WriteLine();
            }

        }
        public void CheckAvailableLawnMower()
        {
            Console.WriteLine("Available Lawn Mowers:");
            int index = 1;
            foreach (LawnMower mower in lawnMowers)
            {
                if (mower.Available)
                {
                    Console.WriteLine($"{index}. Model: {mower.ModelName}, ID: {mower.MowerID}");
                    index++;
                }
            }
        }


        private int GetCustomerIDByPhoneNumber(string phoneNumber)
        {
            var customer = customers.FirstOrDefault(c => c.PhoneNumber == phoneNumber);
            return customer?.CustomerID ?? -1;
        }

        private Customer GetCustomerByID(int customerID)
        {
            return customers.FirstOrDefault(c => c.CustomerID == customerID);
        }

        private LawnMower GetLawnMowerByID(int mowerID)
        {
            return lawnMowers.FirstOrDefault(m => m.MowerID == mowerID);
        }
    }
}
