using System;
using System.Xml.Linq;

namespace Group_1
{
	public class Customer
	{
		public string Name { get; set; }
		public string Type { get; set; }
        public string PhoneNumber { get; set; }
		public List<Rental> Rentals { get; set; }

        public Customer(string name,string type, string phoneNumber)
		{
			Name = name;
			Type = type;
			PhoneNumber = phoneNumber;
			

        }

		

	}
}

