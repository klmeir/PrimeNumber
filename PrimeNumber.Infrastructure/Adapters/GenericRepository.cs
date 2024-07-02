﻿using Microsoft.EntityFrameworkCore;
using PrimeNumber.Domain.Entities;
using PrimeNumber.Infrastructure.DataSource;
using PrimeNumber.Infrastructure.Ports;

namespace PrimeNumber.Infrastructure.Adapters
{
    public class GenericRepository<T> : IRepository<T> where T : DomainEntity
    {
        readonly DataContext Context;
        readonly DbSet<T> _dataset;

        public GenericRepository(DataContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            _dataset = Context.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            _ = entity ?? throw new ArgumentNullException(nameof(entity), "Entity can not be null");
            await _dataset.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

    }
}
