using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject;

namespace DataObject
{
    public interface IOrderDetailDao
    {
        List<OrderDetail> GetOrderDetails();

        OrderDetail GetOrderDetail();

        bool CreateOrderDetail();
        bool UpdateOrderDetail();
        bool DeleteOrderDetail();
    }
}
