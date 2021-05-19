using System;
using System.Collections.Generic;
using System.Text;
using Erbosan.Entities.Concrete;

namespace Erbosan.DataAccess.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
    }
}
