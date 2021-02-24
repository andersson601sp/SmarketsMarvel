using Smarkets.Marvel.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smarkets.Marvel.Domain.Repositories
{
	public interface ISearchHistoryRepository : IReadRepository<SearchHistory>, 
                                                IWriteRepository<SearchHistory>
    {
        Task<IEnumerable<SearchHistory>> GetAllOrderedBySearchDateAsync();
    }
}