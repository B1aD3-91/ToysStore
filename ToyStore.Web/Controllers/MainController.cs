using Microsoft.AspNetCore.Mvc;

namespace ToysStore.Domain.Controllers
{
    public class MainController : Controller
    {
        public ActionResult Index()
        {
            return PartialView();
        }
    }
}