using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SISAS.Application.Interfaces;
using SISAS.Application.Services;
using System.Reflection;
namespace SISAS.Application.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionAplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);




            services.AddValidatorsFromAssemblies(
               AppDomain.CurrentDomain.GetAssemblies()
                   .Where(p => !p.IsDynamic)
           );

            services.AddAutoMapper(cfg =>
            {
            }, Assembly.GetExecutingAssembly());
            services.AddScoped<IAreaApplication, AreaApplication>();
            services.AddScoped<IHorarioApplication, HorarioApplication>();
            return services;
        }
    }
}
