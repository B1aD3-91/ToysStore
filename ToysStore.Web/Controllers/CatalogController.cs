using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ToysStore.Web.Models;
using ToysStore.Web.Models.ViewModel;

namespace ToysStore.Web.Controllers
{
    public class CatalogController : Controller
    {
        DataProjectContext DataPjContext = new DataProjectContext();
        public int pageSize = 10;
        // Получение каталога
        public ActionResult GetCatalog(string category, int page = 1)
        {
            ToyViewModel data = new ToyViewModel
            {
                Toys = DataPjContext.Toys
                .Include(z => z.Category) // Зв’язуємо таблицу товарів з категоріями
                .Where(x => category == null || x.Category.Categories == category) // определяем категорию
                .OrderBy(x => x.Name) // сорутеємо пере використанням Skip
                .Skip((page - 1) * pageSize) // пропускаємо певну кількість 
                .Take(pageSize), // отримуємо певну кількість товарів

                PagingInfo = new Models.WebUI.PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ? DataPjContext.Toys.Count() : DataPjContext.Toys.Where(x => x.Category.Categories == category).Count()
                }, CurrentCategory = category
            };
            ViewBag.Title = "Каталог";
            return PartialView(data);
        }
        // Получение категорий
        public ActionResult GetCategories()
        {
            CategoryViewModel data = new CategoryViewModel
            {
                Categories = DataPjContext.Categories.OrderBy(i => i.Categories)
            };
            return PartialView(data);
        }
        // Поиск по каталогу
        public ActionResult Search(string s)
        {
            ViewBag.Title = "Пошук...";
            ToyViewModel data = new ToyViewModel
            {
                Toys = DataPjContext.Toys.Include(x => x.Category).Where(x => x.Name.ToLower().Contains(s.ToLower()))
            };
            return PartialView(data);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DataPjContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}