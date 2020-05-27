﻿using IdentityModel;
using DOTNET.BaseProjectTemplate.Entities;
using System.Collections.Generic;
using System.Security.Claims;

namespace DOTNET.BaseProjectTemplate.Core.Utils
{
    public static class ClaimExtensions
    {
        public static List<Claim> UserToClaims(this User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Subject, user.Id.ToString()),
                new Claim(JwtClaimTypes.Name, user.UserName)
            };

            return claims;
        }
    }
}