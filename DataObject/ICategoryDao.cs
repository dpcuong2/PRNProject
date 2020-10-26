using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject;

namespace DataObject
{
    public interface ICategoryDao
    {
        List<Category> getCategoryList();

        bool AddCategory();
        bool UpdateCategory();
        bool DeleteCategory();

    }
}
