using System;

namespace Sscs.Application.IntegrationEvents
{
    public class TestIntegrationEvent
    {
        public Guid CompanyId { get; }
        
        public TestIntegrationEvent(Guid companyId)
        {
            CompanyId = companyId;
        }
    }
}