using System;
using Sscs.Domain.SharedKernel;

namespace Sscs.Domain.DomainEvents.Company
{
    public class NewCompanyRegisteredEvent : IDomainEvent
    {
        public Guid CompanyId { get; }

        public NewCompanyRegisteredEvent(Guid companyId)
        {
            CompanyId = companyId;
        }
    }
}