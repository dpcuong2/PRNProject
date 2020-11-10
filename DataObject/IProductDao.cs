using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject;

namespace DataObject
{
    public interface IProductDao
    {
        Product GetProduct(string productId);

        DataTable GetProductsByName(string name);
        DataTable GetProductsByBrand(string brand);
        DataTable GetProductsByCategory(string category);

        bool AddProduct(Product p);
        bool UpdateProduct(Product p);
        bool DeleteProduct(Product p);
    }
}
