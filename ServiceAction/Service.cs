using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using BussinessObject;
using DataObject;
using DataObject.AdoNet;

namespace Service_Action
{
    public class Service : IService
    {
        static readonly IBrandDao brandDao = new BrandDao();
        static readonly ICategoryDao categoryDao = new CategoryDao();
        static readonly ICustomerDao customerDao = new CustomerDao();
        static readonly IOrderDao orderDao = new OrderDao();
        static readonly IOrderDetailDao orderDetailDao = new OrderDetailDao();
        static readonly IProductDao productDao = new ProductDao();
        static readonly IUser userDao = new UserDao();







        public bool AddBrand(Brand b)
        {
            return brandDao.AddBrand(b);
        }

        public bool AddCategory(Category c)
        {
            return categoryDao.AddCategory(c);
        }

        public bool AddProduct(Product p)
        {
            return productDao.AddProduct(p);
        }

        public bool CheckLogin(string userID, string password)
        {
            return userDao.CheckLogin(userID, password);
        }

        public bool CreateOrder(Order o)
        {
            return orderDao.CreateOrder(o);
        }

        public bool CreateOrderDetail(OrderDetail od)
        {
            return orderDetailDao.CreateOrderDetail(od);
        }

        public bool DeleteBrand(Brand b)
        {
            return brandDao.DeleteBrand(b);
        }

        public bool DeleteOrder(Order o)
        {
            return orderDao.DeleteOrder(o);
        }

        public bool DeleteOrderDetail(string orderID)
        {
            return orderDetailDao.DeleteOrderDetail(orderID);
        }

        public bool DeleteProduct(Product p)
        {
            return productDao.DeleteProduct(p);
        }

        public Brand GetBrandByProduct(int productId)
        {
            return brandDao.GetBrandByProduct(productId);
        }

        public DataTable getBrands()
        {
            return brandDao.getBrands();
        }

        public Category GetCategoryByProduct(int productId)
        {
            return categoryDao.GetCategoryByProduct(productId);
        }

        public DataTable GetCategoryList()
        {
            return categoryDao.GetCategoryList();
        }

        public Order GetOrder(int orderId)
        {
            return orderDao.GetOrder(orderId);
        }

        public OrderDetail GetOrderDetail(int orderDetailId)
        {
            return orderDetailDao.GetOrderDetail(orderDetailId);
        }

        public DataTable GetOrderDetails()
        {
            return orderDetailDao.GetOrderDetails();
        }

        public DataTable GetOrderList()
        {
            return orderDao.GetOrderList();
        }

        public Product GetProduct(string productId)
        {
            return productDao.GetProduct(productId);
        }

        public DataTable GetProductsByBrand(string brand)
        {
            return productDao.GetProductsByBrand(brand);
        }

        public DataTable GetProductsByCategory(string category)
        {
            return productDao.GetProductsByBrand(category);
        }

        public DataTable GetProductsByName(string name)
        {
            return productDao.GetProductsByName(name);
        }

        public bool UpdateBrand(Brand b)
        {
            return brandDao.UpdateBrand(b);
        }

        public bool UpdateCategory(Category c)
        {
            return categoryDao.UpdateCategory(c);
        }

        public bool UpdateOrder(Order o)
        {
            return orderDao.UpdateOrder(o);
        }

        public bool UpdateOrderDetail(OrderDetail od)
        {
            return orderDetailDao.UpdateOrderDetail(od);
        }

        public bool UpdateProduct(Product p)
        {
            return productDao.UpdateProduct(p);
        }
    }
}
