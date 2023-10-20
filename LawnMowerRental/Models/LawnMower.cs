using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMowerRental.Models
{
    public class LawnMower
    {
        public int MowerID { get; set; }
        public string ModelName { get; set; }
        public bool Available { get; set; }
    }
}
