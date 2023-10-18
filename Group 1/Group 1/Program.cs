// See https://aka.ms/new-console-template for more information
using Group_1;

Console.WriteLine("Hello, World!");

List<Customer> customers = new List<Customer>();
System();
//LawnMowers();
//Rent();
static void System()
{

    Console.WriteLine("Welcone To Group 1's LawnMower Renalt ");
    Console.WriteLine("1. New Customer");
    Console.WriteLine("2. View Rentals");
    Console.WriteLine("3. Rent");
    Console.WriteLine("Select Option 1-3");

    string option = Console.ReadLine();


    switch (option)
    {
        case "1":
            Customer newCustomer = Group_1.Register.CreateCustomer();
            break;

            //case "2":
            //    LawnMowerStock();
            //    break;

            //case "3";
            //    Rent();
            //    break;
    }

   
}







