using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject;

namespace DataObject
{
    public interface IOrderDao
    {
        DataTable GetOrderList();

        Order GetOrder(int orderId);

        bool DeleteOrder(Order o);
        bool CreateOrder(Order o);
        bool UpdateOrder(Order o);
    }
}
