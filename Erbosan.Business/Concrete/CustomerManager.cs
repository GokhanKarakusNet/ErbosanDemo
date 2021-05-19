using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Erbosan.Business.Abstract;
using Erbosan.Business.Constants;
using Erbosan.DataAccess.Abstract;
using Erbosan.Entities.Concrete;

namespace Erbosan.Business.Concrete
{
    public class CustomerManager:ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomersListed);
        }


        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(p => p.CustomerId == customerId));
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }

        public IResult Delete(int id)
        {
            _customerDal.Delete(new Customer { CustomerId = id });
            return new SuccessResult(Messages.CustomerDeleted);
        }
    }
}
