using System;
using Microsoft.AspNetCore.Identity;

namespace Sscs.Domain.AggregatesModel.CompanyAggregate
{
    public class User : IdentityUser<Guid>
    {
        public Guid CompanyId { get; set; }
        public Company UserCompany { get; set; }
    }
}