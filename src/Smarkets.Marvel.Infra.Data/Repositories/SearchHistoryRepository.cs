using Smarkets.Marvel.Domain.Entities;
using Smarkets.Marvel.Domain.Repositories;
using Smarkets.Marvel.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smarkets.Marvel.Infra.Data.Repositories
{
	public class SearchHistoryRepository : BaseRepository<SearchHistory>, ISearchHistoryRepository
	{
		public SearchHistoryRepository(SmarketsMarvelContext context)
			: base(context)
		{ }

		public Task<IEnumerable<SearchHistory>> GetAllOrderedBySearchDateAsync()
		{
			return Task.FromResult(DbSet.AsQueryable().OrderByDescending(x => x.SearchDate).AsEnumerable());
		}
	}
}