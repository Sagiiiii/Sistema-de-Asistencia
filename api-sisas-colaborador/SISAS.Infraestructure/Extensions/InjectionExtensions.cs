using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SISAS.Infraestructure.Persistences.Contexts;
using SISAS.Infraestructure.Persistences.Interfaces;
using SISAS.Infraestructure.Persistences.Repositories;
using SISAS.Infrastructure.Persistence.Repositories;

namespace SISAS.Infraestructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddIjectionInfraestructure(this IServiceCollection services,IConfiguration configuration)
        {
            // ==============================
            // BD EMPLEADO
            // ==============================
            var sisasAssembly = typeof(EmpleadoDbContext).Assembly.FullName;
            var sisasConnection = configuration.GetConnectionString("EmpleadoConnection");

            services.AddDbContext<EmpleadoDbContext>(
                options => options.UseMySql(
                    sisasConnection,
                    ServerVersion.AutoDetect(sisasConnection),
                    b => b.MigrationsAssembly(sisasAssembly)
                ),
                ServiceLifetime.Transient
            );


            // ==============================
            // BD EMPRESA
            // ==============================
            var empresaAssembly = typeof(EmpresaDbContext).Assembly.FullName;
            var empresaConnection = configuration.GetConnectionString("EmpresaConnection");

            services.AddDbContext<EmpresaDbContext>(
                options => options.UseMySql(
                    empresaConnection,
                    ServerVersion.AutoDetect(empresaConnection),
                    b => b.MigrationsAssembly(empresaAssembly)
                ),
                ServiceLifetime.Transient
            );


            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IAreaRepository, AreaRepository>();
            services.AddScoped<IHorarioRepository, HorarioRepository>();


            return services;
        }
    }
}