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
        
        public void RegisterCompany(string rootUserEmail)
        {
            Id = Guid.NewGuid();
            // В дальнейшем надо давать здесь рутовые права на компанию.
            var rootCompanyUser = new User
            {
                Email = rootUserEmail, 
                CompanyId = Id,
            };
            CompanyUsers.Add(rootCompanyUser);
            
            AddDomainEvent(new NewCompanyRegisteredEvent(Id));
        }
    }
}