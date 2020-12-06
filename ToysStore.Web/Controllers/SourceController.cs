using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ToysStore.Web.Models;
using ToysStore.Web.Models.ViewModel;

namespace ToysStore.Web.Controllers
{
    public class SourceController : Controller
    {
        DataProjectContext DataPjContext = new DataProjectContext();
        public ActionResult Categories()
        {
            CategoryViewModel data = new CategoryViewModel
            {
                Categories = DataPjContext.Categories.OrderBy(i => i.Categories)
            };
            return PartialView(data);
        }
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