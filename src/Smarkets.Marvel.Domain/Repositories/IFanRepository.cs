using Smarkets.Marvel.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smarkets.Marvel.Domain.Repositories
{
	public interface IFanRepository : IReadRepository<Fan>, 
                                                IWriteRepository<Fan>
    {
        Task<IEnumerable<Fan>> GetAllOrderedByFanNameAsync();
    }
}