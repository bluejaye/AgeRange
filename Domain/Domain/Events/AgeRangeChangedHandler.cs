using Domain.Contract.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    internal class AgeRangeChangedHandler : IDomainEventHandler<AgeRangeChangedEvent>
    {
        public Task Handle(AgeRangeChangedEvent domainEvent)
        {
            Console.WriteLine($"[Event] Person {domainEvent.PersonId} changed age range from {domainEvent.OldRange} to {domainEvent.NewRange}");
            return Task.CompletedTask;
        }

    }
}
