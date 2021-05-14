using Core.Entities.Concrete;
using Core.Utilities.Results;
using FinalDataAccess.Abstract;
using FinalDataAccess.Concrete.EntityFreamwork;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalBusiness.Abstract
{
    public interface IUserService
    {

        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);
    }
}
