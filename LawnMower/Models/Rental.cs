﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LawnMowerRentalAssignment.RentalItem;

namespace LawnMowerRentalAssignment {
    public enum RentalItem {
        LawnMower
    }
    public class Rental {
        protected int maxStock;
        protected DateTime rentalStartDate;
        public decimal Price { get; set; }

        public Rental() {
            rentalStartDate = DateTime.Now;

        }
    }


}