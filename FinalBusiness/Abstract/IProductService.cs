using FinalEntities.Concrete;
using FinalDataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalBusiness.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
    }
}
