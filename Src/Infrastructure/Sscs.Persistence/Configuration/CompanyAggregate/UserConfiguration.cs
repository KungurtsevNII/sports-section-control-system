using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sscs.Domain.AggregatesModel.CompanyAggregate;

namespace Sscs.Persistence.Configuration.CompanyAggregate
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.CompanyId).HasColumnName("CompanyId");

            builder
                .HasOne(x => x.UserCompany)
                .WithMany(x => x.CompanyUsers)
                .HasForeignKey(x => x.CompanyId);
        }
    }
}