using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMowerRentalAssignment
{
    public abstract class RentalItem
    {
        public int MaxStock { get { return GetMaxStock(); } }
        public decimal PricePerDay { get { return GetPricePerDay(); } }

        protected abstract int GetMaxStock();
        protected abstract decimal GetPricePerDay();

        public int GetStock() {
            int stock = MaxStock - RentalManager.GetRentedCount(this);
            return stock;
        }

        public virtual string GetItemName() {
            return GetType().Name;
        }

        public override string ToString() {
            return "Item: " + GetItemName() + ", Maxstock: " + MaxStock + ", Price per day: " + PricePerDay;
        }
    }
}
