using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ToysStore.Web.Models;
using ToysStore.Web.Models.DomainModel;
using ToysStore.Web.Models.ViewModel;

namespace ToysStore.Web.Controllers
{
    public class CartController : Controller
    {
        private DataProjectContext data = new DataProjectContext();

        public ViewResult Index(Cart cart, string returnUrl)
        {
            ViewBag.Title = "Корзина покупця";
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public PartialViewResult AddToCart(int? Id, Cart cart = null)
        {
            Toy toy = data.Toys.Include(x => x.Category).FirstOrDefault(x => x.Id == Id);
            if (toy != null)
            {
                cart.AddItem(toy, 1);
            }
            return PartialView(cart);
        }

        public RedirectToRouteResult RemovefromCart(Cart cart, int Id, string returnUrl)
        {
            Toy toy = data.Toys.Include(x => x.Category).FirstOrDefault(x => x.Id == Id);
            if (toy != null)
            {
                cart.RemoveList(toy);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

    }
}