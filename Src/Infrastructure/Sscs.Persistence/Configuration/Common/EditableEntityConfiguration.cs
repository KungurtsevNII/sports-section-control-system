using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sscs.Domain.Common;

namespace Sscs.Persistence.Configuration.Common
{
    public abstract class EditableEntityConfiguration<T> 
        : EntityConfiguration<T> where T : EditableEntity
    {
        protected override void FieldConfiguration(EntityTypeBuilder<T> builder)
        {
            builder.Property(d => d.CreateDate).HasColumnName("CreatedAt");
            builder.Property(d => d.CreateUserId).HasColumnName("CreatedBy");
            builder.Property(d => d.IsDeleted).HasColumnName("IsDeleted");
            builder.Property(d => d.ModifyDate).HasColumnName("ModifiedAt");
            builder.Property(d => d.ModifyUserId).HasColumnName("ModifiedBy");
        }
    }
}