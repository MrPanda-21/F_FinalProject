using Core.DataAccess.EntityFramework;
using FinalDataAccess.Abstract;
using FinalEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalDataAccess.Concrete.EntityFreamwork
{
    public class EfOrderDal:EFEntityRepositoryBase<Order,NorthwindContext>, IOrderDal
    {
    }
}
