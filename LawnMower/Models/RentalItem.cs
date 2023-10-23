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
       Electrical1,
       Electrical2,
       Petrol
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

        public double GetEffect()
        {
            switch (Id) {
                case ItemType.Electrical1:
                    return 75.6;
                  //  break;
                    case ItemType.Electrical2:
                    return 146;
                 //   break;
                case ItemType.Petrol:
                    return 862;
                //  break;
                default:
                    return 0;

            }
        }

        public string GetUnit()
        {
            if(Id==ItemType.Petrol)
            {
                return "g / kWh";
            }
            else
            { 
                return "wH";
            }
        }

        public string  GetEffectToString()
        {
            return GetEffect()+GetUnit();
        }
    }
}
