﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class Order:BusinessObject
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime Date { get; set; }
        public float TotalPrice { get; set; }
        public bool Status { get; set; }
        public int Discount { get; set; }
        public string Address { get; set; }

    }
}
