using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sscs.Domain.AggregatesModel.CompanyAggregate;

namespace Sscs.Application.Common
{
    public interface ISscsDbContext
    {
        // TODO поправить этот момент.
        public DbSet<Company> Companies { get; set; }
        
        public DbSet<User> Users { get; set; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}