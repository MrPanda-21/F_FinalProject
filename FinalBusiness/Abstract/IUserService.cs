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
        IDataResult<User> GetUserByMail(string email);
        IDataResult<User> GetUserById(int Id);
        IDataResult<List<User>> GetAll();
        IResult Add(User car);
        IResult Update(User car);
        IResult Delete(User car);
        IDataResult<List<OperationClaim>> GetClaims(User user);
    }
}
