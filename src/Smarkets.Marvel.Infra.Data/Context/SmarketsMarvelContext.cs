using Microsoft.EntityFrameworkCore;
using Smarkets.Marvel.Infra.Data.Mapping;
using Smarkets.Marvel.Domain.Entities;

namespace Smarkets.Marvel.Infra.Data.Context
{
	public class SmarketsMarvelContext : DbContext
	{
		public SmarketsMarvelContext(DbContextOptions options): base(options){ }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new SearchHistoryMapping());
			modelBuilder.ApplyConfiguration(new FanMapping());
		}

	}
}