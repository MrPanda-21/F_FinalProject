using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FinalDataAccess.Abstract;
using FinalEntities.Concrete;

namespace FinalDataAccess.Concrete.EntityFreamwork
{
    public class EfCategoryDal:ICategoryDal
    {
        public EfCategoryDal()
        {
        }

        public void Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
