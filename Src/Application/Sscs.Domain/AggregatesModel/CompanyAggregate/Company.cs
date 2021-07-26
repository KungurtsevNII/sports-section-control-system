using System;
using System.Collections.Generic;
using Sscs.Domain.DomainEvents.Company;
using Sscs.Domain.SharedKernel;

namespace Sscs.Domain.AggregatesModel.CompanyAggregate
{
    public class Company : EditableEntity, IAggregateRoot
    {
        public string Name { get; set; }

        public ICollection<User> CompanyUsers { get; } = new List<User>();

        public Company() { }

        public Company(string name)
        {
            Name = name;
        }
        
        public void RegisterCompany(User companyOwner)
        {
            Id = Guid.NewGuid();
            CompanyUsers.Add(companyOwner);
            AddDomainEvent(new NewCompanyRegisteredEvent(Id));
        }
    }
}