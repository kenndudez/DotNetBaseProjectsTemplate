using Microsoft.AspNetCore.Identity;
using DOTNET.BaseProjectTemplate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;
using DOTNET.BaseProjectTemplate.Core.ViewModels;

namespace DOTNET.BaseProjectTemplate.Core.UserManagement
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IEnumerable<UserVM>> GetUsers(string email, string branchCode)
        {
            var branchClaim = new Claim("BRANCH", branchCode);
            var branchUsers = await _userManager.GetUsersForClaimAsync(branchClaim);
            IEnumerable<User> users = branchUsers;
            if(!string.IsNullOrEmpty(email))
                users = branchUsers.Where(x => x.Email.ToLower() == email.ToLower());

            return users.Select(x => (UserVM)x);
        }
    }
}
