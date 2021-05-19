using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Erbosan.Business.Abstract;
using Erbosan.Business.Constants;
using Erbosan.DataAccess.Abstract;
using Erbosan.Entities.Concrete;

namespace Erbosan.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

       
        

        public ProductManager(IProductDal productDal) 
        {
            _productDal = productDal;
        }

        public IDataResult<List<Product>> GetAll()
        {
           
            if (DateTime.Now.Hour == 4)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IResult Add(Product product)
        {

            var result = BusinessRules.Run( CheckIfProductNameExists(product.ProductName));
            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

       
        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        public IResult Delete(int id)
        {
           _productDal.Delete(new Product{ProductId = id});
           return new SuccessResult(Messages.ProductDeleted);
        }

        public IResult TransactionalOperation(Product product)
        {
            _productDal.Update(product);
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        

        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }

    
    }
}
