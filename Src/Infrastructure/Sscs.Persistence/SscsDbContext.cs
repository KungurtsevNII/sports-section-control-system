using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sscs.Application.Common;
using Sscs.Domain.AggregatesModel.CompanyAggregate;

namespace Sscs.Persistence
{
    public class SscsDbContext : IdentityDbContext<User>, ISscsDbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        
        public SscsDbContext(DbContextOptions<SscsDbContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}