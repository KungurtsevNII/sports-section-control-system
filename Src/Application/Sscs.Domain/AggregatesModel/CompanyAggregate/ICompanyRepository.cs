using System.Threading;
using System.Threading.Tasks;
using Sscs.Domain.SharedKernel;

namespace Sscs.Domain.AggregatesModel.CompanyAggregate
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task AddCompany(Company company, CancellationToken ct = default);
    }
}