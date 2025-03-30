﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Spider.Shared.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TEntity> DbSet<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        DatabaseFacade Database { get; }
    }
}
