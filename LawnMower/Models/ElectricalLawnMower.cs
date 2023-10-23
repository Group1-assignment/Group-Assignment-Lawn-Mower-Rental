using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LawnMowerRentalAssignment.Models
{
    public class ElectricalLawnMower:RentalItem
    {
        public double BatteryCapacity { get; set; }

        public ElectricalLawnMower(int maxStock, decimal price, ItemType itemType,double batteryCapacity)
        : base(maxStock,price,itemType)
        {
            BatteryCapacity = batteryCapacity;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($" Battery Capacity: {BatteryCapacity} Wh");
        }
    }
}
