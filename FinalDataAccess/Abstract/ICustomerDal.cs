using System;
using FinalEntities.Concrete;
using System.Text;

namespace FinalDataAccess.Abstract
{
    public interface ICustomerDal:IEntityRepository<Customer>
    {
    }
}
