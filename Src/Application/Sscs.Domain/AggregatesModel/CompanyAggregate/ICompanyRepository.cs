using System.Threading;
using System.Threading.Tasks;
using Sscs.Domain.Common;

namespace Sscs.Domain.AggregatesModel.CompanyAggregate
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task AddCompany(string companyName, CancellationToken ct = default);
    }
}