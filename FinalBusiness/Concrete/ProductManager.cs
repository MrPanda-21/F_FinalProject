using FinalBusiness.Abstract;
using FinalEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using FinalDataAccess.Abstract;
using FinalEntities.DTO;
using Core.Utilities.Results;
using FinalBusiness.Constants;

namespace FinalBusiness.Concrete
{
    public class ProductManager : IProductService
    {
        public IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            //business codes
            if (product.ProductName.Length<2)
            {
                //magic string
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
            
            
        }

        public IDataResult<List<Product>> GetAll()
        {
            //Business Codes
            //Yetkisi var mı?
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int Id)
        {
           
           return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == Id), Messages.ProductsListed);
        }

        public IDataResult<Product> GetById(int productId)
        {
             
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId), Messages.ProductsListed);

        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
           
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max), Messages.ProductsListed);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetail()
        {
            return new SuccessDataResult<List<ProductDetailDto>>( _productDal.GetProductDetails(),Messages.ProductsListed);
        }
    }
}
