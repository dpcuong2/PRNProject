using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
    public interface IDaoFactory
    {
        IBrandDao BrandDao { get;  }
        ICategoryDao CategoryDao { get;  }
        ICustomerDao CustomerDao { get; }
        IOrderDao OrderDao { get; }
        IOrderDetailDao OrderDetailDao { get;  }
        IProductDao ProductDao { get; }
    }
}
