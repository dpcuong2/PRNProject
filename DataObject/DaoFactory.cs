using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
    class DaoFactory : IDaoFactory
    {
        public IBrandDao BrandDao => throw new NotImplementedException();

        public ICategoryDao CategoryDao => throw new NotImplementedException();

        public ICustomerDao CustomerDao => throw new NotImplementedException();

        public IOrderDao OrderDao => throw new NotImplementedException();

        public IOrderDetailDao OrderDetailDao => throw new NotImplementedException();

        public IProductDao ProductDao => throw new NotImplementedException();
    }
}
