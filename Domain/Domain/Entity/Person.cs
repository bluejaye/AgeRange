using Domain.Contract.Events;
using Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class Person
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long? Age { get; set; }
        public string AgeRange { get; set; }

        private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void UpdateAge(long newAge)
        {
            var oldRange = AgeRange;
            Age = newAge;
            AgeRange = CalculateAgeRange(newAge);

            if (oldRange != AgeRange)
            {
                var evt = new AgeRangeChangedEvent(Id, oldRange, AgeRange);
                _domainEvents.Add(evt);
            }
        }
        public void ClearDomainEvents() => _domainEvents.Clear();

        private string CalculateAgeRange(long age)
        {
            if (age<18) return "Child";
            if (age < 65) return "Adult";
            return "Senior";
        }
    }
}
