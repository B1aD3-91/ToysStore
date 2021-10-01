using Microsoft.AspNetCore.Mvc;


namespace ToysStore.Domain.Controllers
{
    public class ContactsController : Controller
    {
        // GET: Contacts
        public ActionResult Index()
        {
            return View();
        }
    }
}