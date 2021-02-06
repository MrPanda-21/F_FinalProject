using Core.DataAccess;
using FinalEntities.Concrete;
using FinalEntities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalDataAccess.Abstract
{
    public interface IProductDal: IEntityRepository<Product>
    {
        List<ProductDetailDto> GetProductDetails();
    }
}

//Code Refactoring
