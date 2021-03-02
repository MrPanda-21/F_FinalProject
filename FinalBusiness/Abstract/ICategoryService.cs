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

        IResult Delete(Category category);
        IResult Update(Category category);
        IResult Add(Category category);
    }
}
