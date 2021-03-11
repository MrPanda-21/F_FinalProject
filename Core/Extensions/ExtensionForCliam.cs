using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Extensions
{
    public static class ExtensionForCliam
    {
        public static void AddEmail(this ICollection<Claim> claims, User user)
        {
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
        }

        public static void AddName(this ICollection<Claim> claims, User user)
        {
            claims.Add(new Claim(ClaimTypes.Name, user.FirstName +" "+ user.LastName));
        }

        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }

        public static void AddId(this ICollection<Claim> claims, User user)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
        }
    }
}
