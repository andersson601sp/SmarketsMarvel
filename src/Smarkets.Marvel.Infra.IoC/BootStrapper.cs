using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smarkets.Marvel.Infra.IoC.Extensions;

namespace Smarkets.Marvel.Infra.IoC
{
	public class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMarvelApi(configuration);
            services.AddMarvelAppRepositories(configuration);
            services.AddAppServices();
        }
    }
}