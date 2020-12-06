using System.Data.Entity;
using ToysStore.Web.Models.DomainModel;
namespace ToysStore.Web.Models
{
    public class DataProjectContext : DbContext
    {
        public DataProjectContext() : base("ToysContext")
        {

        }

        public DbSet<Toy> Toys { get; set; }
        public DbSet<ToyCategory> Categories { get; set; }
    }
}