﻿using Application.IRepository;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repository;

namespace Persistence
{
    public static class DependencyInyection
    {
        public static void AddPersistence(this IServiceCollection services)
        {
            services.AddSingleton<DapperContext>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<ICajaRepository, CajaRepository>();
            services.AddScoped<IAperturaRepository, AperturaRepository>();
            services.AddScoped<ILocalRepository, LocalRepository>();
            services.AddScoped<IPuntoJuegoRepository, PuntoJuegoRepository>();
            services.AddScoped<ITransaccionesRepository, TransaccionesRepository>();
            services.AddScoped<IScratchRepository, ScratchRepository>();
            services.AddScoped<IRolRepository, RolRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}
