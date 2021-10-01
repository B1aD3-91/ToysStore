using Microsoft.AspNetCore.Mvc;

using System.Linq;

using ToysStore.Domain.Service;
using ToysStore.Web.Models.ViewModel;
using ToysStore.Web.Models.WebUI;

namespace ToysStore.Domain.Controllers
{
    public class CatalogController : Controller
    {
        private const int PageSize = 20;
        
        IProductService service;
        public CatalogController(IProductService service)
        {
            this.service = service;
        }

        // Получение каталога
        public IActionResult GetCatalog(string category, int page = 1)
        {
            var toyRange = service.GetProductRange(category, page, PageSize);
            ToyViewModel data = new ToyViewModel
            {
                Toys = toyRange,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? toyRange.Count() : toyRange.Where(x => x.Category.Name == category).Count()
                },
                CurrentCategory = category
            };
            ViewBag.Title = "Каталог";
            return PartialView(data);
        }
        // Получение категорий
        public IActionResult GetCategories()
        {
            CategoryViewModel data = new CategoryViewModel
            {
                Categories = service.GetCategories().OrderBy(i => i.Name)
            };
            return PartialView(data);
        }
        // Поиск по каталогу
        public IActionResult Search(string search)
        {
            ViewBag.Title = "Пошук...";
            ToyViewModel data = new ToyViewModel
            {
                Toys = service.GetProducts().Where(x => x.Name.ToLower().Contains(search.ToLower()))
            };
            return PartialView(data);
        }
    }
}