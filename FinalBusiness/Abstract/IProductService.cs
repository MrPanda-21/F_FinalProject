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
        List<Product> GetAll();
        List<Product> GetAllByCategoryId(int Id);
        List<Product> GetByUnitPrice(decimal min, decimal max);
        List<ProductDetailDto> GetProductDetail();
        IResult Add(Product product);
        Product GetById(int productId);
    }
}
