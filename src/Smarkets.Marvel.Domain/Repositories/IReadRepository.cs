using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Smarkets.Marvel.Domain.Repositories
{
	public interface IReadRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> condition);

        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}