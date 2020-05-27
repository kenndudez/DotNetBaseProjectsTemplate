﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.BaseProjectTemplate.Core.DataAccess.EfCore.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();

        Task<int> SaveChangesAsync();

        void BeginTransaction();

        void Commit();

        void Rollback();
    }
}
