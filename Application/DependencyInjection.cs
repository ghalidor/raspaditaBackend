﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            //services.AddSingleton<DapperContext>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}