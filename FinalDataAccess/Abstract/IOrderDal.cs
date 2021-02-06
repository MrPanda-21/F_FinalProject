using Core.DataAccess;
using FinalEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalDataAccess.Abstract
{
    public interface IOrderDal:IEntityRepository<Order>
    {
    }
}
