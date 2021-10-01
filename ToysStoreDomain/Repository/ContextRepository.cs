using Microsoft.EntityFrameworkCore;

using ToysStore.Domain.Model;

namespace ToysStore.Domain.Repository
{
    public class ContextRepository : DbContext
    {
        public ContextRepository(DbContextOptions<ContextRepository> options) : base(options)
        {
            Database.EnsureCreated();
        }

        internal DbSet<Product> Toys { get; set; }
        internal DbSet<Category> Categories { get; set; }
    }
}
