using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject;

namespace DataObject
{
    public interface IProductDao
    {
        Product GetProduct();

        List<Product> GetProductsByName(string name);
        List<Product> GetProductsByBrand(string brand);
        List<Product> GetProductsByCategory(string category);

        bool AddProduct();
        bool UpdateProduct();
        bool DeleteProduct();
    }
}
