using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using FinalDataAccess.Abstract;
using FinalEntities.Concrete;

namespace FinalDataAccess.Concrete.EntityFreamwork
{
    public class EfCategoryDal: EFEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {
        
    }
}
