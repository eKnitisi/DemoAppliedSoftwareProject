using AP.BTP.Application.Interfaces;
using AP.BTP.Infrastructure.Contexts;
using AP.BTP.Infrastructure.Repositories;
using AP.BTP.Infrastructure.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DotNetEnv;


namespace AP.BTP.Infrastructure.Extensions
{
    public static class Registrator
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
        {
            services.RegisterDbContext();
            services.RegisterRepositories();
            return services;
        }

        public static IServiceCollection RegisterDbContext(this IServiceCollection services)
        {
            Env.Load();
            services.AddDbContext<BTPContext>(options =>
                        options.UseSqlServer(Environment.GetEnvironmentVariable("CONNECTION_STRING")));
            return services;

        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
