using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using FinalEntities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalBusiness.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto);
        IDataResult<AccessToken> CreateAccessToken(User user);
        IResult UserExist(User user);
    }
}
