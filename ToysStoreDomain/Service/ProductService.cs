using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using ToysStore.Domain.Model;
using ToysStore.Domain.Repository;

namespace ToysStore.Domain.Service
{
    public class ProductService : IProductService
    {
        private readonly ContextRepository rep;

        public ProductService(ContextRepository rep)
        {
            this.rep = rep;
        }

        public async Task<Product> AddProductAsync(Product toy)
        {
            var result = await rep.Toys.AddAsync(
                toy ?? throw new ArgumentException("Argument must not be null"));
            await rep.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            var result = await rep.Categories.AddAsync(
                category ?? throw new ArgumentException("Argument must not be null"));
            await rep.SaveChangesAsync();
            return result.Entity;
        }

        public IQueryable<Product> GetProducts()
        {
            return rep.Toys.AsQueryable().Include(x => x.Category);
        }

        public IQueryable<Category> GetCategories()
        {
            return rep.Categories.AsQueryable();
        }

        public IQueryable<Category> GetCategory(long? id)
        {
            return rep.Categories.AsQueryable().Where(x => x.Id == id);
        }

        public IQueryable<Product> GetProduct(long? id)
        {
            return rep.Toys.AsQueryable().Include(x => x.Category).Where(x => x.Id == id);
        }

        public IQueryable<Product> GetProductRange(string category, int range, int pageSize = 20)
        {
            return rep.Toys.AsQueryable()
                .Where(x => category == null || category == x.Category.Name)
                .OrderBy(x => x.Name)
                .Skip((range - 1) * pageSize)
                .Take(pageSize);
        }
    }
}
