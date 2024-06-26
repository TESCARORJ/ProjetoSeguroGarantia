﻿using Microsoft.Extensions.DependencyInjection;
using ProjetoSeguroGarantia.Application.Interfaces;
using ProjetoSeguroGarantia.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSeguroGarantia.Application.Extensions
{
    /// <summary>
    /// Classe de extensão para configurar os serviços
    /// da camada de aplicação do sistema
    /// </summary>
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //configurando o MediatR
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });

            //configurando o AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //registrando as interfaces/classes de serviço da aplicação
            services.AddTransient<ISeguroGarantiaApplicationService, SeguroGarantiaApplicationService>();

            return services;
        }
    }
}
