using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smarkets.Marvel.Application.Interfaces;
using Smarkets.Marvel.Application.Services;
using Smarkets.Marvel.Domain.Repositories;
using Smarkets.Marvel.Infra.Data;
using Smarkets.Marvel.Infra.Data.Context;
using Smarkets.Marvel.Infra.Data.Repositories;

namespace Smarkets.Marvel.Infra.IoC.Extensions
{
	public static class InjectorExtensions
    {
        public static void AddMarvelApi(this IServiceCollection services, IConfiguration config)
        {
            var marvelHost = config.GetSection("MarvelApi:Host").Value;
            var marvelPublicKey = config.GetSection("MarvelApi:PublicKey").Value;
            var marvelPrivateKey = config.GetSection("MarvelApi:PrivateKey").Value; ;

            services.AddTransient<ICharacterClient, CharacterClient>();
            services.AddTransient<IMarvelClient>(x => new MarvelClient(marvelPublicKey, marvelPrivateKey, marvelHost));
        }

        public static void AddMarvelAppRepositories(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<SmarketsMarvelContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Smarkets.Marvel.Infra.Data.Migrations")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISearchHistoryRepository, SearchHistoryRepository>();            
        }

        public static void AddAppServices(this IServiceCollection services)
        {
           services.AddScoped<ISearchAppService, SearchAppService>();
        }
    }
}