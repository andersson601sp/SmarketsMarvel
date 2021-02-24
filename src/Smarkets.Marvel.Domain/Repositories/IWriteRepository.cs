using System.Threading.Tasks;

namespace Smarkets.Marvel.Domain.Repositories
{
	public interface IWriteRepository<TEntity>
    {
        Task InsertAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);
    }
}