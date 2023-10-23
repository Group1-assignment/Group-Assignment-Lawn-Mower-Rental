using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMowerRentalAssignment
{
    public enum ItemType
    {
        LawnMower
    }
    public class RentalItem
    {
        public int MaxStock { get; }
        public decimal PricePerDay { get; }
        public ItemType Id { get; }

        public RentalItem(int maxStock, decimal price, ItemType itemType) {
            Id = itemType;
            MaxStock = maxStock;
            PricePerDay = price;
        }

        public override string ToString() {
            return "Id: " + Id + ", Maxstock: " + MaxStock + ", Price per day: " + PricePerDay;
        }
    }
}
