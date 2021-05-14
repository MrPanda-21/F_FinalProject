using FinalBusiness.Abstract;
using FinalEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using FinalDataAccess.Abstract;
using FinalEntities.DTO;
using Core.Utilities.Results;
using FinalBusiness.Constants;
using FluentValidation;
using FinalBusiness.ValidationRules.FluentValidition;
using Core.CrossCuttingConcerns.Validation;
using Core.Aspects.Autofac.Validation;
using System.Linq;
using Core.Utilities.Business;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac;
using FinalBusiness.BusinessAspects.Autofac;

namespace FinalBusiness.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;
       
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
          
            
        }

        [SecuredOperation("products.add")]
        [PerformanceAspect(interval:3)]
        [CacheRemoveAspect("IProductService.Get")]
        [CacheAspect(duration:200,Priority = 2)]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductNameExist(product.ProductName),
                CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                CheckIfCategoryCountAvaible());
            if (result != null)
            {
                return result;
            }

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);

            //validation codes are different things.
            //if (product.UnitPrice <= 0)
            //{
            //    return new ErrorResult(Messages.UnitPriceInvalid);
            //}
            //if (product.ProductName.Length<2)
            //{
            //    //magic string
            //    return new ErrorResult(Messages.ProductNameInvalid);
            //}

            //var context = new ValidationContext<Product>(product);//doğrulanacak olanı al
            //ProductValidator productValidatior = new ProductValidator();//Hangi kurallar
            //var result = productValidatior.Validate(context);//doğrula
            //if (!result.IsValid)
            //{
            //    throw new ValidationException(result.Errors);//error yolla api
            //}

        }
        [CacheAspect]
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

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => categoryId == p.CategoryId).Count;
            if (result >= 20)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }
        private IResult CheckIfProductNameExist(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCategoryCountAvaible()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count> 15)
            {
                return new ErrorResult(Messages.CountNotAvaible);
            }
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            Add(product);
            return null;
        }
    }
}
