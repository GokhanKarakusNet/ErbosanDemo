using System;
using System.Collections.Generic;
using System.Text;
using Erbosan.DataAccess.Abstract;
using Erbosan.Entities.Concrete;

namespace Erbosan.DataAccess.Concrete.EntityFramework
{
    public class EfSalesDal : EfEntityRepositoryBase<Sales, ErbosanContext>, ISalesDal
    {
    }
}
