using System;
using Microsoft.AspNetCore.Identity;

namespace Sscs.Domain.AggregatesModel.CompanyAggregate
{
    public class User : IdentityUser
    {
        public Guid CompanyId { get; set; }
        public Company UserCompany { get; set; }
    }
}