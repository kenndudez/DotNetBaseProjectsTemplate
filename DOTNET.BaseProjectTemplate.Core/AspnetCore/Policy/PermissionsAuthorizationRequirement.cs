using Microsoft.AspNetCore.Authorization;
using DOTNET.BaseProjectTemplate.Core.Permissions;
using System.Collections.Generic;

namespace SDOTNET.BaseProjectTemplate.Core.Policy
{
    public class PermissionsAuthorizationRequirement : IAuthorizationRequirement
    {
        public IEnumerable<Permission> RequiredPermissions { get; }

        public PermissionsAuthorizationRequirement(IEnumerable<Permission> requiredPermissions)
        {
            RequiredPermissions = requiredPermissions;
        }
    }
}