using FinalEntities.Concrete;
using FinalDataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using FinalEntities.DTO;
using Core.Utilities.Results;

namespace FinalBusiness.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int Id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetail();
        IResult Add(Product product);
        IDataResult<Product> GetById(int productId);
    }





}
