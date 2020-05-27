﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DOTNET.BaseProjectTemplate.Core.DataAccess.EfCore.Context;
using DOTNET.BaseProjectTemplate.Web.Utils;

namespace DOTNET.BaseProjectTemplate.Web
{
    public partial class Startup
    {
        private IWebHostEnvironment HostingEnvironment { get; set; }
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            HostingEnvironment = webHostEnvironment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddSwagger();
            services.AddControllers();

            AddEntityFrameworkDbContext(services);
            ConfigureIdentity(services);
            AddIdentityProvider(services);
            ConfigureDIService(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCustomSwaggerApi();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers()
                .RequireAuthorization();
            });
        }

        public void AddEntityFrameworkDbContext(IServiceCollection services)
        {
            string dbConnStr = Configuration.GetConnectionString("Default");

            services.AddDbContextPool<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(dbConnStr,
                 b => b.MigrationsAssembly(typeof(ApplicationDbContext).FullName));
            });
        }
    }
}
