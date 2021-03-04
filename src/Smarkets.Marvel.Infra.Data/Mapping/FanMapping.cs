using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smarkets.Marvel.Domain.Entities;

namespace Smarkets.Marvel.Infra.Data.Mapping
{
	public class FanMapping : IEntityTypeConfiguration<Fan>
    {
        public void Configure(EntityTypeBuilder<Fan> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)                
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.Cpf)
                 .HasMaxLength(14)
                .IsRequired();

            builder
               .Property(x => x.Email)
                .HasMaxLength(50)
               .IsRequired();

            builder
              .Property(x => x.DataNascimento)
               .HasMaxLength(10)
              .IsRequired();
        }
    }
}