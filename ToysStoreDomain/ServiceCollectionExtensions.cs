
using Microsoft.Extensions.DependencyInjection;

using ToysStore.Domain.Repository;

namespace ToysStore.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDomainServiceExtension(this IServiceCollection collection)
        {
            collection.AddDbContext<ContextRepository>();
        }
    }
}
