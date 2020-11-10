using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class OrderDetail:BusinessObject
    {
        public int OrderDetailID { get; set; }
        public string ProductID { get; set; }
        public DateTime Date { get; set; }
        public float TotalPrice { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }

    }
}
