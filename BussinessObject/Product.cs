using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class Product
    {
        public string  ProductID { get; set; }
        public string  Name { get; set; }
        public int Quantity { get; set; }
        public string CategoryID{ get; set; }
        public string BrandID{ get; set; }
        public float Price{ get; set; }
    }
}
