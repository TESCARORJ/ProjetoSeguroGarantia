using Microsoft.Extensions.DependencyInjection;
using ProjetoSeguroGarantia.Domain.Interfaces.Services;
using ProjetoSeguroGarantia.Domain.Services;

namespace ProjetoSeguroGarantia.Domain.Extensions
{
    public static class DomainServicesExtension
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient<ISeguroGarantiaDomainService, SeguroGarantiaDomainService>();

            return services;
        }
    }
}
