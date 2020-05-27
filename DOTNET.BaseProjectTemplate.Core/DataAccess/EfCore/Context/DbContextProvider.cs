﻿using Microsoft.EntityFrameworkCore;
using DOTNET.BaseProjectTemplate.Core.DataAccess.EfCore.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOTNET.BaseProjectTemplate.Core.DataAccess.EfCore.Context
{
    public interface IDbContextProvider<out TDbContext>
       where TDbContext : DbContext
    {
        TDbContext GetDbContext();
    }

    public sealed class UnitOfWorkDbContextProvider<TDbContext> : IDbContextProvider<TDbContext>
      where TDbContext : DbContext
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkDbContextProvider(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public TDbContext GetDbContext()
        {
            return _unitOfWork.GetDbContext<TDbContext>();
        }
    }
}
