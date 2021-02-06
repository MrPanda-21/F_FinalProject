using System;
using System.Collections.Generic;
using Core.DataAccess;
using FinalEntities.Concrete;

namespace FinalDataAccess.Abstract
{
    public interface ICategoryDal: IEntityRepository<Category>
    {
        
    }
}
