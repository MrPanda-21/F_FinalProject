using Core.Utilities.Results;
using FinalEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalBusiness.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> GetById(int categoryId);
    }
}
