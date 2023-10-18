using System;
using System.Xml.Linq;

namespace Group_1
{
	public class CustomerList
	{
		public string CustomerName { get; set; }
		public string CustomerType { get; set; }
        public string PhoneNumber { get; set; }
		public List<Rental> Rentals { get; set; }

        public CustomerList (string customer,string customerType, string phoneNumber)
		{
			CustomerName = customer;
			CustomerType = customerType;
			PhoneNumber = phoneNumber;
			

        }

		

	}
}

