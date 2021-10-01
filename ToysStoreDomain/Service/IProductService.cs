using System.Linq;
using System.Threading.Tasks;

using ToysStore.Domain.Model;

namespace ToysStore.Domain.Service
{
    public interface IProductService
    {
        Task<Product> AddProductAsync(Product toy);
        Task<Category> AddCategoryAsync(Category category);

        IQueryable<Product> GetProducts();
        IQueryable<Category> GetCategories();

        IQueryable<Product> GetProductRange(string category, int range, int pageSize);

        IQueryable<Category> GetCategory(long? id);
        IQueryable<Product> GetProduct(long? id);
    }
}
