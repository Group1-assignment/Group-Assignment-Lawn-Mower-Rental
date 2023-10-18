// See https://aka.ms/new-console-template for more information
using Group_1;

Console.WriteLine("Hello, World!");


List<CustomerList> customers = new List<CustomerList>();

Console.WriteLine("Welcone To Group 1's Lawn Mower Renalt ");
Console.WriteLine("1. New Customer");
Console.WriteLine("2. View Rentals");
Console.WriteLine("3. Rent");
Console.WriteLine("Select Option 1-3");

string option = Console.ReadLine();


switch (option)
{
    case "1":
        NewCustomer();
        break;

    //case "2":
    //    LawnMowers();
    //    break;

    //case "3";
    //    Rent();
    //    break;
}







