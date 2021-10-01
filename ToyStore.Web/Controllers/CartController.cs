using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Threading.Tasks;
using ToysStore.Domain.Service;
using ToysStore.Web.Models.DomainModel;
using ToysStore.Web.Models.ViewModel;

namespace ToysStore.Domain.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService service;

        public CartController(IProductService service)
        {
            this.service = service;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            ViewBag.Title = "Корзина покупця";
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public async Task<PartialViewResult> AddToCart(long? id, Cart cart = null)
        {
            cart.AddItem(await service.GetProduct(id).FirstAsync(), 1);
            return PartialView(cart);
        }

        public async Task<RedirectToActionResult> RemovefromCart(Cart cart, int id, string returnUrl)
        {
            cart.RemoveList(await service.GetProduct(id).FirstOrDefaultAsync());
            return RedirectToAction("Index", new { returnUrl });
        }

    }
}