using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject;

namespace DataObject
{
    public interface IProduct
    {
        Product GetProduct();

        List<Product> GetProducts();

        bool AddProduct();
        bool UpdateProduct();
        bool DeleteProduct();
    }
}
