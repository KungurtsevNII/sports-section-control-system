using System.Collections.Generic;
using Sscs.Domain.Common;

namespace Sscs.Domain.AggregatesModel.CompanyAggregate
{
    public class Company : EditableEntity, IAggregateRoot
    {
        public string Name { get; set; }

        public ICollection<User> CompanyUsers { get; } = new List<User>();
    }
}