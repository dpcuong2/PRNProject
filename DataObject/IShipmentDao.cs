﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject;

namespace DataObject
{
    public interface IShipmentDao
    {
        Shippment GetShippment();

        bool AddShipment();
        bool UpdateShipment();
    }
}
