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

        public async Task AddCompany(string companyName, CancellationToken ct = default)
        {
            _dbContext.Companies.Add(new Company
            {
                Name = companyName
            });

            await _dbContext.SaveChangesAsync(ct);
        }
    }
}