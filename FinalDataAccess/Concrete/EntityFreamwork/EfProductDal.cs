using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using FinalDataAccess.Abstract;
using FinalEntities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace FinalDataAccess.Concrete.EntityFreamwork
{
    public class EfProductDal:EFEntityRepositoryBase<Product,NorthwindContext>, IProductDal
    {
       
    }
}
