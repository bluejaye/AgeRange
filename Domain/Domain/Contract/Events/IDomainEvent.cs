using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Contract.Events
{
    public class IDomainEvent
    {
        DateTime OccurredOn { get; }
    }
}
