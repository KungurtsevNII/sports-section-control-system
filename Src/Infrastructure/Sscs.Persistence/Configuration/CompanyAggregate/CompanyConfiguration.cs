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
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("Id");
        }
        
        protected override void FieldConfiguration(EntityTypeBuilder<Company> builder)
        {
            base.FieldConfiguration(builder);
            
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.HasMany(x => x.CompanyUsers).WithOne(x => x.UserCompany);
        }
    }
}