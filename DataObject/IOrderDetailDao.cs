using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject;

namespace DataObject
{
    public interface IOrderDetailDao
    {
        DataTable GetOrderDetails();

        OrderDetail GetOrderDetail(int orderDetailId);

        bool CreateOrderDetail(OrderDetail od);
        bool UpdateOrderDetail(OrderDetail od);
        bool DeleteOrderDetail(string orderDetaiID);
    }
}
