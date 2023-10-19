using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMowerRentalAssignment {
    public class LawnMower : Rental {
        public LawnMower() {
            maxStock = 15;
            Price = 50;
        }
    }
}
