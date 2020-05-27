using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using DOTNET.BaseProjectTemplate.Core.AspNetCore;
using DOTNET.BaseProjectTemplate.Core.DataAccess.EfCore;
using DOTNET.BaseProjectTemplate.Core.DataAccess.EfCore.Context;
using DOTNET.BaseProjectTemplate.Core.DataAccess.EfCore.UnitOfWork;
using DOTNET.BaseProjectTemplate.Core.FileStorage;
using SBSC.NET.BaseTemplate.Core.UserManagement;
using DOTNET.BaseProjectTemplate.Core.Utils;
using DOTNET.BaseProjectTemplate.Web.Svc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DOTNET.BaseProjectTemplate.Core.UserManagement;

namespace DOTNET.BaseProjectTemplate.Web
{
    public partial class Startup
    {
        public void ConfigureDIService(IServiceCollection services)
        {
            services.AddTransient<DbContext, ApplicationDbContext>();

            services.AddScoped<IUnitOfWork, EfCoreUnitOfWork>();
            services.AddScoped(typeof(IDbContextProvider<>), typeof(UnitOfWorkDbContextProvider<>));

            services.RegisterGenericRepos(typeof(ApplicationDbContext));

            services.AddScoped<IHttpUserService, HttpUserService>();
            services.AddHttpContextAccessor();

            //Permission not needed here
            //services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();

            services.AddScoped<IUserService, UserService>();

            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(
                          HostingEnvironment.ContentRootPath, Configuration.GetValue<string>("StoragePath"))));
            services.AddScoped<IBaseRequestAPIService, BaseRequestAPIService>();

            services.RegisterGenericRepos(typeof(ApplicationDbContext));

            services.AddScoped<IFileStorageService, FileStorageService>();
            //services.AddTransient<IFileUploadService, FileUploadService>();        }
        }
    }
}
