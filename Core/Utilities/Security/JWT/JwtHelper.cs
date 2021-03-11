using Core.Entities.Concrete;
using Core.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        TokenOptions _tokenOptions;
        DateTime ExpirationDate;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
           
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            var _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            SecurityKey securityKey = Encryption.SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            SigningCredentials signingCredentials = Encryption.SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions,operationClaims,user,signingCredentials);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            var accessToken = new AccessToken
            {
                Expiriation = _accessTokenExpiration,
                Token = token
            };
            return accessToken;
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, List<OperationClaim> operationClaims, User user, SigningCredentials signingCredentials)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                claims: GenerateToClaim(user, operationClaims),
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration),
                signingCredentials: signingCredentials
                );
            return jwt;
        }

        public IEnumerable<Claim> GenerateToClaim(User user,List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddEmail(user);
            claims.AddId(user);
            claims.AddName(user);
            claims.AddRoles(operationClaims.Select(o => o.Name).ToArray());
            return claims;
        }
    }
}
