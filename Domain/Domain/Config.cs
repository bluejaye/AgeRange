
using Domain.Contract.Events;
using Domain.Events;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Domain
{
    public static class Config
    {
        public static void ConfigureDependencies(IServiceCollection services)
        {
            //Services injection configuration
            services.AddScoped<Contract.Service.IPerson, Service.Person>();
            services.AddScoped<Contract.Events.IDomainEvent, Domain.Events.AgeRangeChangedEvent>();
            services.AddScoped<Contract.Events.IDomainEventDispatcher, Domain.Events.SimpleDomainEventDispatcher>();
            services.AddScoped<Contract.Events.IDomainEventHandler<AgeRangeChangedEvent>, Domain.Events.AgeRangeChangedHandler>();
        }
    }
}
