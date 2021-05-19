using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities.DTOs;
using Erbosan.DataAccess.Abstract;
using Erbosan.Entities.Concrete;

namespace Erbosan.DataAccess.Concrete.EntityFramework
{
   public class EfProductDal:EfEntityRepositoryBase<Product,ErbosanContext>,IProductDal
    {

       
    }
}
