using Microsoft.Extensions.DependencyInjection;
using Smarkets.Marvel.Application.AutoMapper;
using System;

namespace Smarkets.Marvel.ApiExtensions
{
	public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddTransient(x => AutoMapperConfig.RegisterMappings().CreateMapper());                      
        }
    }
}