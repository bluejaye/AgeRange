
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
        }
    }
}
