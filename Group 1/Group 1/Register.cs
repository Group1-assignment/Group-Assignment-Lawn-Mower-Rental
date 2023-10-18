using System;
namespace Group_1
{
	public class Register
	{



        public static Customer CreateCustomer()
        {
            // Ta Info

            Console.WriteLine("Please Enter Customer Name");
            string customerName = Console.ReadLine();

            Console.WriteLine("Please Enter Customer Type");
            string customerType = Console.ReadLine();

            Console.WriteLine("Please Enter Phone Number");
            string phoneNumber = Console.ReadLine();


            Customer newCustomer = new Customer(customerName, customerType, phoneNumber);


            

            return newCustomer;


        }






    }
}

