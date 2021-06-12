using Microsoft.AspNetCore.Identity;

namespace Sscs.Domain.AggregatesModel.CompanyAggregate
{
    public class User : IdentityUser
    {
        public long CompanyId { get; set; }
        public Company UserCompany { get; set; }
    }
}