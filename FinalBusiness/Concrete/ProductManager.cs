using FinalBusiness.Abstract;
using FinalEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using FinalDataAccess.Abstract;

namespace FinalBusiness.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public List<Product> GetAll()
        {
            //iş kodları
            //Yetkisi var mı?

            return _productDal.GetAll();
        }
    }
}
