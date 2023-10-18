using System;
using System.Collections.Generic;

class Customer
{
    public int CustomerID { get; }
    public string Name { get; }
    public string PhoneNumber { get; }
    public string Address { get; }

    public Customer(int id, string name, string phoneNumber, string address)
    {
        CustomerID = id;
        Name = name;
        PhoneNumber = phoneNumber;
        Address = address;
    }
}

class LawnMower
{
    public string Model { get; }
    public string ID { get; }
    public bool IsAvailable { get; set; }

    public LawnMower(string model, string id)
    {
        Model = model;
        ID = id;
        IsAvailable = true;
    }
}

class Program
{
    static List<Customer> customers = new List<Customer>();
    static List<LawnMower> lawnMowers = new List<LawnMower>();

    static void Main(string[] args)
    {
        InitializeLawnMowers();
        bool runApp = true;

        while (runApp)
        {
            Console.WriteLine("Welcome to Lawn Mower Rental Console App!");
            Console.WriteLine("1. Register New Customer");
            Console.WriteLine("2. Register Lawn Mower Rental");
            Console.WriteLine("3. View Customers with Rentals");
            Console.WriteLine("4. View Available Lawn Mowers");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice (number): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RegisterNewCustomer();
                    break;
                case "2":
                    RegisterLawnMowerRental();
                    break;
                case "3":
                    ViewCustomersWithRentals();
                    break;
                case "4":
                    ViewAvailableLawnMowers();
                    break;
                case "5":
                    runApp = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void InitializeLawnMowers()
    {
        
        for (int i = 1; i <= 15; i++)
        {
            string mowerID = "LM" + i.ToString().PadLeft(3, '0');
            LawnMower mower = new LawnMower("L2023S", mowerID);
            lawnMowers.Add(mower);
        }
    }

    static void RegisterNewCustomer()
    {
        Console.Write("Enter customer name: ");
        string name = Console.ReadLine();

        Console.Write("Enter phone number: ");
        string phoneNumber = Console.ReadLine();

        Console.Write("Enter address: ");
        string address = Console.ReadLine();

        int customerID = customers.Count + 1;
        Customer newCustomer = new Customer(customerID, name, phoneNumber, address);
        customers.Add(newCustomer);

        Console.WriteLine($"Customer registered successfully! Customer ID: {customerID}");
    }

    static void RegisterLawnMowerRental()
    {
        Console.Write("Enter customer ID: ");
        int customerID = int.Parse(Console.ReadLine());

        
        Customer customer = customers.Find(c => c.CustomerID == customerID);
        if (customer == null)
        {
            Console.WriteLine("Invalid customer ID. Please register the customer first.");
            return;
        }

        Console.Write("Enter rental duration (in days): ");
        int rentalDuration = int.Parse(Console.ReadLine());

        Console.WriteLine("Available Lawn Mowers:");
        int index = 1;
        foreach (LawnMower mower in lawnMowers)
        {
            if (mower.IsAvailable)
            {
                Console.WriteLine($"{index}. Model: {mower.Model}, ID: {mower.ID}");
                index++;
            }
        }

        Console.Write("Enter lawn mower number to rent: ");
        int mowerNumber = int.Parse(Console.ReadLine()) - 1;

        
        if (mowerNumber >= 0 && mowerNumber < lawnMowers.Count && lawnMowers[mowerNumber].IsAvailable)
        {
            LawnMower selectedMower = lawnMowers[mowerNumber];
            selectedMower.IsAvailable = false;
            Console.WriteLine($"Rental confirmed! Rental ID: RNTL{customerID}{mowerNumber}");
        }
        else
        {
            Console.WriteLine("Invalid lawn mower number or the mower is not available for rental.");
        }
    }

    static void ViewCustomersWithRentals()
    {
        Console.WriteLine("Customers with Rentals:");
        foreach (Customer customer in customers)
        {
            // Assume there is a method to retrieve rentals based on customer ID
            // List<Rental> rentals = GetRentalsByCustomerID(customer.CustomerID);
            // foreach (Rental rental in rentals)
            // {
            //     Console.WriteLine($"Customer ID: {customer.CustomerID}, Name: {customer.Name}");
            //     Console.WriteLine($"Rental ID: {rental.RentalID}, Mower ID: {rental.MowerID}, Duration: {rental.Duration} days");
            // }
        }
    }

    static void ViewAvailableLawnMowers()
    {
        Console.WriteLine("Available Lawn Mowers:");
        int index = 1;
        foreach (LawnMower mower in lawnMowers)
        {
            if (mower.IsAvailable)
            {
                Console.WriteLine($"{index}. Model: {mower.Model}, ID: {mower.ID}");
                index++;
            }
        }
    }
}
