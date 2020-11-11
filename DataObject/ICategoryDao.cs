using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject;

namespace DataObject
{
    public interface ICategoryDao
    {
        DataTable GetCategoryList();

        bool AddCategory(Category c);
        bool UpdateCategory(Category c);

        Category GetCategoryByProduct(int productId);

    }
}
