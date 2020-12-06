using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ToysStore.Web.Models;
using ToysStore.Web.Models.ViewModel;

namespace ToysStore.Web.Controllers
{
    public class ToyController : Controller
    {
        DataProjectContext DataPjContext = new DataProjectContext();
        public int pageSize = 2;
        public ActionResult Catalog(string category, int page = 1)
        {
            ToyViewModel data = new ToyViewModel
            {
                Toys = DataPjContext.Toys
                .Include(z => z.Category) // Связываем таблицу категорий
                .Where(x => category == null || x.Category.Categories == category) // определяем категорию
                .OrderBy(x => x.Id) // сортируем перед использованием Ski
                .Skip((page - 1) * pageSize) // пропускаем определенное количество елементов
                .Take(pageSize), // получаем нужное количество елементов 

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