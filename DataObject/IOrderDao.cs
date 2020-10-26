using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject;

namespace DataObject
{
    public interface IOrderDao
    {
        List<Order> GetOrderList();

        Order GetOrder();

        bool DeleteOrder();
        bool CreateOrder();
        bool UpdateOrder();
    }
}
