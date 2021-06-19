using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sscs.Application.Common;
using Sscs.Domain.AggregatesModel.CompanyAggregate;
using Sscs.Domain.SharedKernel;

namespace Sscs.Persistence
{
    public class SscsDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>, ISscsDbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        
        public SscsDbContext(DbContextOptions<SscsDbContext> options) : base(options) { }
        
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var utcNow = DateTime.UtcNow;
            
            foreach (var entry in ChangeTracker.Entries<EditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        //entry.Entity.CreateUserId = userId;
                        entry.Entity.CreateDateUtc = utcNow;
                        entry.Entity.ModifyDateUtc = utcNow;
                        //entry.Entity.ModifyUserId = userId;
                        entry.Entity.IsDeleted = false;
                        break;
                    case EntityState.Modified:
                        //entry.Entity.ModifyUserId = userId;
                        entry.Entity.ModifyDateUtc = utcNow;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        //entry.Entity.ModifyUserId = userId;
                        entry.Entity.ModifyDateUtc = utcNow;
                        entry.Entity.IsDeleted = true;
                        break;
                }
            }
            
            return base.SaveChangesAsync(cancellationToken);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}