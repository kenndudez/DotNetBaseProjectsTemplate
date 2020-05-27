using DOTNET.BaseProjectTemplate.Core.ViewModels;
using DOTNET.BaseProjectTemplate.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SBSC.NET.BaseTemplate.Core.UserManagement
{
    public interface IUserService
    {
        Task<IEnumerable<UserVM>> GetUsers(string jobFunction, string branchCode);
    }
}
