using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class Shippment:BusinessObject
    {
        public int ShipmentID { get; set; }
        public int OrderID { get; set; }
        public DateTime Date{ get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
