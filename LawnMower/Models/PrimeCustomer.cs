using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMowerRentalAssignment.Models
{
    class PrimeCustomer:Customer
    {
        public decimal PointsPerDay { get; set; } // bonus p 

        public PrimeCustomer(string name, int phoneNumber, CustomerType customerType) : base(name, phoneNumber, customerType) { }


        // går att använda samma typ som pris
        decimal Points() {


            return PointsPerDay;
        }
    }
}
