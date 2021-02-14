using FinalBusiness.Abstract;
using FinalEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using FinalDataAccess.Abstract;
using FinalEntities.DTO;
using Core.Utilities.Results;

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
            _productDal.Add(product);
            return new Result(true,"Ürün eklendi!!!");
        }

        public List<Product> GetAll()
        {
            //Business Codes
            //Yetkisi var mı?

            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int Id)
        {
            return _productDal.GetAll(p => p.CategoryId == Id);
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p => p.ProductId == productId)
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetail()
        {
            return _productDal.GetProductDetails();
        }
    }
}
