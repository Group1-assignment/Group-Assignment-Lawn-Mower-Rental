using System;
namespace Group_1
{
	public class Register
	{
        List<CustomerList> customers = new List<CustomerList>();

        public CustomerList NewCustomer()
		{
			// Ta Info

			Console.WriteLine("Please Enter Customer Name");
			string customer = Console.ReadLine();

			Console.WriteLine("Please Enter Customer Type");
			string customertype = Console.ReadLine();

			Console.WriteLine("Please Enter Phonenumber");
			string phonenumber = Console.ReadLine();


            CustomerList newCustomer = new CustomerList(customer,customertype ,
				phonenumber);

            customers.Add(newCustomer);



			return newCustomer;


		}

        
		
		



    }
}

