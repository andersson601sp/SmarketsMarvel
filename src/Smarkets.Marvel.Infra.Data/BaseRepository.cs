using Microsoft.EntityFrameworkCore;
using Smarkets.Marvel.Domain.Repositories;
using Smarkets.Marvel.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Smarkets.Marvel.Infra.Data
{
	public class BaseRepository<TEntity> : IReadRepository<TEntity>, 
                                           IWriteRepository<TEntity> where TEntity : class
    {
        protected SmarketsMarvelContext Context { get; private set; }
        protected DbSet<TEntity> DbSet { get; private set; }

        public BaseRepository(SmarketsMarvelContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public Task DeleteAsync(TEntity entity)
        {
            return Task.FromResult(DbSet.Remove(entity));
        }

        public Task InsertAsync(TEntity entity)
        {
            return Task.FromResult(DbSet.Add(entity));
        }

        public Task UpdateAsync(TEntity entity)
        {
            return Task.FromResult(DbSet.Update(entity));
        }

        public Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> condition)
        {
            return Task.FromResult(DbSet.AsQueryable().Where(condition).AsEnumerable());
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return Task.FromResult(DbSet.AsEnumerable());
        }
    }
}