using Domain.Contract.Events;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public class SimpleDomainEventDispatcher: IDomainEventDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public SimpleDomainEventDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task DispatchAsync(IEnumerable<IDomainEvent> events)
        {
            foreach (var domainEvent in events)
            {
                var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(domainEvent.GetType());
                var handlers = _serviceProvider.GetServices(handlerType);

                foreach (var handler in handlers)
                {
                    await ((Task)handlerType
                    .GetMethod("Handle")
                    .Invoke(handler, new object[] { domainEvent }));
                }
            }
        }

    }
}
