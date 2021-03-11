using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using FinalDataAccess.Abstract;
using System.Linq;

namespace FinalDataAccess.Concrete.EntityFreamwork
{
    public class EfUserDal : EFEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new NorthwindContext())
            {
                var result = from OperationClaim in context.OperationClaims
                             join UserOperationClaim in context.UserOperationClaims
                                on OperationClaim.Id equals UserOperationClaim.OperationClaimId
                             where OperationClaim.Id == user.Id
                             select new OperationClaim { Id = OperationClaim.Id, Name = OperationClaim.Name };
                return result.ToList();
            }
        }
    }
}
