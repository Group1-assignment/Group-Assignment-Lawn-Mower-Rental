using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMowerRentalAssignment {
    public class RentalManager {
        private List<Customer> customers = new List<Customer>();

        public void RegisterNewCustomer(Customer customer) {
            customers.Add(customer);
        }


    }


}
