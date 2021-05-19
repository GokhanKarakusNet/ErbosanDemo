using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Erbosan.Entities.Concrete;

namespace Erbosan.Business.Abstract
{
   public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetById(int customerId);
        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(int id);
    }
}
