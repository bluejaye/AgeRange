using Domain.Contract.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class AgeRangeChangedEvent: IDomainEvent
    {
        public long PersonId { get; set; }
        public string OldRange { get; set; }
        public string NewRange { get; set; }
        public DateTime OccuredOn { get; set; } = DateTime.UtcNow;

        public AgeRangeChangedEvent(long personId, string oldRange, string newRange)
        {
            PersonId = personId;
            OldRange = oldRange;
            newRange = newRange;
        }
    }
}
