using AP.BTP.Application.Interfaces;
using AP.BTP.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AP.BTP.Application.Extensions
{
    public static class Registrator
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICountryService, CountryService>();
            return services;
        }
    }
}
