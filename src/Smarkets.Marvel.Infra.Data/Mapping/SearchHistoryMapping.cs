using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smarkets.Marvel.Domain.Entities;

namespace Smarkets.Marvel.Infra.Data.Mapping
{
	public class SearchHistoryMapping : IEntityTypeConfiguration<SearchHistory>
    {
        public void Configure(EntityTypeBuilder<SearchHistory> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.SearchTerm)                
                .HasMaxLength(250)
                .IsRequired();

            builder
                .Property(x => x.SearchDate)                
                .IsRequired();
        }
    }
}