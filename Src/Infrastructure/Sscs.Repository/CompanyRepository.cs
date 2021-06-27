using System.Threading;
using System.Threading.Tasks;
using Sscs.Application.Common;
using Sscs.Domain.AggregatesModel.CompanyAggregate;

namespace Sscs.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ISscsDbContext _dbContext;

        public CompanyRepository(ISscsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddCompany(Company company, CancellationToken ct = default)
        {
            _dbContext.Companies.Add(company);
            await _dbContext.SaveChangesAsync(ct);
        }
    }
}