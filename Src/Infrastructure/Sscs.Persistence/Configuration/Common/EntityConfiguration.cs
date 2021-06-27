using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sscs.Domain.SharedKernel;

namespace Sscs.Persistence.Configuration.Common
{
    public abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T> where T : Entity
    {
        protected abstract string TableName { get; }
        protected virtual string PkName => TableName + "ID";

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            TableConfiguration(builder);
            PkConfiguration(builder);
            FieldConfiguration(builder);
        }

        protected virtual void TableConfiguration(EntityTypeBuilder<T> builder)
        {
            builder.ToTable(TableName);
        }

        protected virtual void PkConfiguration(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(a => a.Id);
            var pkName = PkName;
            builder.Property(d => d.Id).HasColumnName(pkName);
        }

        protected abstract void FieldConfiguration(EntityTypeBuilder<T> builder);
    }
}