using Data.Base;
using Data.Repository;
using Domain.Contract;
using Domain.Contract.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public static class Config
    {
        public static void ConfigureDependencies(IServiceCollection services)
        {
            //EF context Injection
            services.AddScoped<AgeRangerDbContext>(x => new AgeRangerDbContext());

            // Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Repository injection configuration
            services.AddScoped<IPerson, Person>();
            services.AddScoped<IAgeGroup, AgeGroup>();
        }
    }
}
