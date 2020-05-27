﻿using Microsoft.AspNetCore.Authorization;
using SBSC.NET.BaseTemplate.Core.AspNetCore.Policy;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DOTNET.BaseProjectTemplate.Core.Permissions
{
    public class PermissionAuthorizationHandler
       : AuthorizationHandler<PermissionsAuthorizationRequirement>
    {
        public PermissionAuthorizationHandler()
        {
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionsAuthorizationRequirement requirement)
        {
            var currentUserPermissions = context.User.Claims
                .Where(x => x.Type.Equals(nameof(Permission))).Select(x => x.Value);

            var authorized = await Task.Run(() =>
            {
                return requirement.RequiredPermissions//.AsParallel()
                      .All(rp => currentUserPermissions.Contains(rp.ToString()));
            });
            if (authorized) context.Succeed(requirement);
        }
    }
}