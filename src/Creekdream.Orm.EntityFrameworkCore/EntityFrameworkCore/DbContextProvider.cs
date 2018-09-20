﻿using Microsoft.EntityFrameworkCore;
using Creekdream.Dependency;
using Microsoft.EntityFrameworkCore.Storage;

namespace Creekdream.Orm.EntityFrameworkCore
{
    /// <inheritdoc />
    public class DbContextProvider : IDbContextProvider
    {
        private DbContext _dbContext;

        private readonly IIocResolver _iocResolver;

        /// <inheritdoc />
        public DbContextProvider(IIocResolver iocResolver)
        {
            _iocResolver = iocResolver;
        }

        /// <inheritdoc />
        public DbContext GetDbContext()
        {
            if (_dbContext == null)
            {
                _dbContext = _iocResolver.Resolve<DbContext>();
            }
            return _dbContext;
        }

        /// <inheritdoc />
        public IDbContextTransaction DbContextTransaction { get; set; }

        /// <inheritdoc />
        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext = null;
            }
        }
    }
}

