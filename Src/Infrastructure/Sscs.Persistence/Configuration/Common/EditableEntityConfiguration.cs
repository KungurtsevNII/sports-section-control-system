using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sscs.Domain.SharedKernel;

namespace Sscs.Persistence.Configuration.Common
{
    public abstract class EditableEntityConfiguration<T> 
        : EntityConfiguration<T> where T : EditableEntity
    {
        protected override void FieldConfiguration(EntityTypeBuilder<T> builder)
        {
            builder.Property(d => d.CreateDateUtc).HasColumnName("CreatedAt");
            builder.Property(d => d.CreateUserId).HasColumnName("CreatedBy");
            builder.Property(d => d.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);
            builder.Property(d => d.ModifyDateUtc).HasColumnName("ModifiedAt");
            builder.Property(d => d.ModifyUserId).HasColumnName("ModifiedBy");
        }
    }
}