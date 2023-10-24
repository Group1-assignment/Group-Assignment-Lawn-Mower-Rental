using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LawnMowerRentalAssignment
{
    public abstract class RentalItem
    {
        [JsonIgnore]
        public virtual int MaxStock { get { return GetMaxStock(); } }
        [JsonIgnore]
        public decimal PricePerDay { get { return GetPricePerDay(); } }
        [JsonIgnore]
        public string Name { get { return GetItemName(); } }

        protected static int GetMaxStock() {
            return 0;
        }
        protected abstract decimal GetPricePerDay();

        public int GetStock() {
            int stock = MaxStock - RentalManager.GetRentedCount(this);
            return stock;
        }

        protected virtual string GetItemName() {
            return GetType().Name;
        }

        public override string ToString() {
            return "Item: " + GetItemName() + ", Maxstock: " + MaxStock + ", Price per day: " + PricePerDay;
        }
    }
}
