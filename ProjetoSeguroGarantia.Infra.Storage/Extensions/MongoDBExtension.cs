using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ProjetoSeguroGarantia.Infra.Storage.Contexts;
using ProjetoSeguroGarantia.Infra.Storage.Persistence;
using ProjetoSeguroGarantia.Infra.Storage.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSeguroGarantia.Infra.Storage.Extensions
{
    public static class MongoDBExtension
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            var mongodbSettings = new MongoDBSettings();

            //ler as configurações do /appsettings.json
            new ConfigureFromConfigurationOptions<MongoDBSettings>
                (configuration.GetSection("MongoDB"))
                .Configure(mongodbSettings);

            //registrando as configurações
            services.AddSingleton(mongodbSettings);

            services.AddSingleton<MongoDBContext>();
            services.AddTransient<SeguroGarantiaPersistence>();

            return services;
        }
    }
}
