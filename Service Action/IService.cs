using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject;

namespace Service_Action
{
    public interface IService
    {
        // Category Repository

        bool AddCategory(Category c);

        DataTable GetCategoryList();
        Category GetCategoryByProduct(int productId);


        bool UpdateCategory(Category c);

        // Brand Repository
        DataTable getBrands();
        Brand GetBrandByProduct(int productId);
        bool UpdateBrand(Brand b);
        bool AddBrand(Brand b);
        bool DeleteBrand(Brand b);

        // Product Repository

        bool AddProduct(Product p);
        bool DeleteProduct(Product p);
        Product GetProduct(string productId);
        DataTable GetProductsByBrand(string brand);
        DataTable GetProductsByCategory(string category);
        DataTable GetProductsByName(string name);
        bool UpdateProduct(Product p);

        // User Repository
        bool CheckLogin(string userID, string password);

        // Order Repository
        bool CreateOrder(Order o);
        DataTable GetOrderList();

        Order GetOrder(int orderId);
        bool DeleteOrder(Order o);
        bool UpdateOrder(Order o);
        // OrderDetail Repository
        bool CreateOrderDetail(OrderDetail od);
        bool DeleteOrderDetail(string orderID);
        OrderDetail GetOrderDetail(int orderDetailId);
        DataTable GetOrderDetails();
        bool UpdateOrderDetail(OrderDetail od);


    }
}
