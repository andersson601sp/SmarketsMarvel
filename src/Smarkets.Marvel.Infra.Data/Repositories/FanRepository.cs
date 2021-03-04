using Smarkets.Marvel.Domain.Entities;
using Smarkets.Marvel.Domain.Repositories;
using Smarkets.Marvel.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smarkets.Marvel.Infra.Data.Repositories
{
	public class FanRepository : BaseRepository<Fan>, IFanRepository
	{
		public FanRepository(SmarketsMarvelContext context)
			: base(context)
		{ }

        public Task<IEnumerable<Fan>> GetAllOrderedByFanNameAsync()
        {
			return Task.FromResult(DbSet.AsQueryable().OrderByDescending(x => x.Name).AsEnumerable());
		}
    }
}