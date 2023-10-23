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
        public ItemType ItemType { get; }

        public RentalItem(int maxStock, decimal price, ItemType itemType) {
            ItemType = itemType;
            MaxStock = maxStock;
            PricePerDay = price;
        }

        public int GetStock() {
            int stock = MaxStock - RentalManager.GetRentedCount(ItemType);
            return stock;
        }

        public override string ToString() {
            return "Id: " + ItemType + ", Maxstock: " + MaxStock + ", Price per day: " + PricePerDay;
        }
    }
}
