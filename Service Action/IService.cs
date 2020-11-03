using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject;

namespace Service_Action
{
    public interface IService
    {
        // Category Repository

        List<Category> GetCategories();
        Category GetCategoryByProduct(int productID);
        Category GetCategoryByBrand(int brandID);

        // Brand Repository
        List<Brand> GetBrands();

        Brand GetBrandByProduct(int productID);

        Brand GetBrandByCategory(int categoryID);

        // Product Repository

        Product GetProduct(int productId);
        List<Product> GetProductsByCategory(int categoryID);
        List<Product> GetProductsByBrand(int brandID);
        List<Product> SearchProducts(string productName, double min, double max);

        // Member Repository
        User GetUser(int userID);
        List<User> GetUsers();
        User GetUserByOrder(int orderID);
        void InsertUser(User user);
        void UpdateUser(User user);
        void DeleteUser(string userID);

        // Order Repository
        #region Order Repository

        Order GetOrder(int orderID);
        List<Order> GetOrdersByUser(int userID);
        List<Order> GetOrdersByDate(DateTime dateFrom, DateTime dateThru);

        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(string orderID);

        #endregion
        // OrderDetail Repository

        List<OrderDetail> GetOrderDetails(int orderId);
        bool Login(string userID, string password);
        void Logout();
    }
}
