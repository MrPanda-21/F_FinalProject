using System;
using FinalEntities.Concrete;
using System.Text;
using Core.DataAccess;

namespace FinalDataAccess.Abstract
{
    public interface ICustomerDal:IEntityRepository<Customer>
    {
    }
}
