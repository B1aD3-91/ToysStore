
using Microsoft.Extensions.DependencyInjection;
using ToysStore.Domain.Service;

namespace ToysStore.Web
{

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainServiceExtension(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            return services;
        }
    }
}
