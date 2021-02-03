using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FinalDataAccess.Abstract;
using FinalEntities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace FinalDataAccess.Concrete.EntityFreamwork
{
    public class EfProductDal:IProductDal
    {
        public EfProductDal()
        {
        }

        public void Add(Product entity)
        {
            //IDisposable pattern implemention
            using (NorthwindContext context = new NorthwindContext())
            {
                var AddedEntity = context.Entry(entity);
                AddedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var DeletedEntity = context.Entry(entity);
                DeletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var UpdatedEntity = context.Entry(entity);
                UpdatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
