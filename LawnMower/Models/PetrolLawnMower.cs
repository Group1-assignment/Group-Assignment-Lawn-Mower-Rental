using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMowerRentalAssignment.Models
{
   public class PetrolLawnMower:RentalItem
    {
        public double CO2Emission { get; set; }
        public PetrolLawnMower(int maxStock, decimal price, ItemType itemType, double co2Emission)
        : base(maxStock, price, itemType)
        {
            CO2Emission=co2Emission;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($" Battery Capacity: {CO2Emission} Wh");
        }
    }
}
