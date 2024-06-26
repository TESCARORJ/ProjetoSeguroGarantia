﻿using Microsoft.OpenApi.Models;
using System.Reflection;

namespace ProjetoSeguroGarantia.API.Extensions
{
    /// <summary>
    /// Classe de extensão para configuração do Swagger (OPEN API)
    /// </summary>
    public static class SwaggerDocExtension
    {
        /// <summary>
        /// Método de extensão para configurar as preferências do Swagger
        /// </summary>
        public static IServiceCollection AddSwaggerDoc(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "Projeto Seguro Garantia API",
                        Description = "API para controle de Seguro Garantia .",
                        Version = "1.0",
                      
                    });

                    //configuração para incluir os comentários na documentação
                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    options.IncludeXmlComments(xmlPath);
                });

            return services;
        }

        /// <summary>
        /// Método para configurar a execução do Swagger
        /// </summary>
        public static IApplicationBuilder UseSwaggerDoc(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "SeguroGarantia");
            });

            return app;
        }
    }
}
