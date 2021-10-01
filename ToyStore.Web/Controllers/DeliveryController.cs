using Microsoft.AspNetCore.Mvc;

namespace ToysStore.Domain.Controllers
{
    public class DeliveryController : Controller
    {
        // GET: Delivery
        public ActionResult Index()
        {
            return View();
        }
    }
}