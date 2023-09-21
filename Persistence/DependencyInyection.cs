using Application.IRepository;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repository;

namespace Persistence
{
    public static class DependencyInyection
    {
        public static void AddPersistence(this IServiceCollection services)
        {
            services.AddSingleton<DapperContext>();
            services.AddScoped<IEnvioRepository, EnvioRepository>();
            services.AddScoped<ICajaRepository, CajaRepository>();
            services.AddScoped<ILocalRepository, LocalRepository>();
            services.AddScoped<IPuntoJuegoRepository, PuntoJuegoRepository>();
            services.AddScoped<ITransaccionesRepository,TransaccionesRepository>();
        }
    }
}
