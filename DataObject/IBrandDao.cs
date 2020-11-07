using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject;

namespace DataObject
{
    public interface IBrandDao
    {
        DataTable getBrands();

        bool UpdateBrand();

        bool AddBrand();
        bool DeleteBrand();


    }
}
