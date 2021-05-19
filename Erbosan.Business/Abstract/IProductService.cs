using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.DTOs;
using Erbosan.Entities.Concrete;

namespace Erbosan.Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<Product> GetById(int productId);
        IResult Add(Product product);
        IResult Update(Product product);
        IResult Delete(int id);
    }
}
