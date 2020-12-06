using System.Web.Mvc;

namespace ToysStore.Web.Controllers
{
    public class MainController : Controller
    {
        public ActionResult Index()
        {
            return PartialView();
        }
    }
}