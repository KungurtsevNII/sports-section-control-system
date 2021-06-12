using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sscs.Domain.AggregatesModel.CompanyAggregate;
using Sscs.Persistence.Configuration.Common;

namespace Sscs.Persistence.Configuration.CompanyAggregate
{
    public class CompanyConfiguration : EditableEntityConfiguration<Company>
    {
        protected override string TableName => "Companies";

        protected override void PkConfiguration(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(d => d.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");
        }
        
        protected override void FieldConfiguration(EntityTypeBuilder<Company> builder)
        {
            builder.Property(x => x.Name).HasColumnName("Name");

            builder.HasMany(x => x.CompanyUsers).WithOne(x => x.UserCompany);
        }
    }
}