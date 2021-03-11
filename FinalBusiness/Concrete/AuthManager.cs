using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using FinalBusiness.Abstract;
using FinalDataAccess.Abstract;
using FinalEntities.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Security.Hashing;
using FinalBusiness.Constants;

namespace FinalBusiness.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var token = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(token,Messages.TokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var user = _userService.GetUserByMail(userForLoginDto.email);
            if (user == null)
            {
                return new ErrorDataResult<User>(Messages.WrongMail);
            }
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForLoginDto.password, out passwordHash, out passwordSalt);
            var result = HashingHelper.VerifyPasswordHash(userForLoginDto.password, passwordHash, passwordSalt);
            if (result)
            {
                return new SuccessDataResult<User>(user.Data,Messages.Logined);
            }
            return new ErrorDataResult<User>(Messages.IncorrectPassword);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            
            byte[]  passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Pasword,out passwordHash,out passwordSalt);

            var user = new User { Email = userForRegisterDto.Email, FirstName = userForRegisterDto.FirstName, LastName = userForRegisterDto.LastName, Status = true, PasswordHash = passwordHash, PasswordSalt = passwordSalt };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.Registered);
        }

        public IResult UserExist(User user)
        {
            var result = _userService.GetUserByMail(user.Email);
            if (result != null)
            {
                return new SuccessResult(result.Message);
            }
            return new ErrorResult(result.Message);
        }
    }
}
