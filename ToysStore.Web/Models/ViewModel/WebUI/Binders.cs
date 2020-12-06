using System.Web.Mvc;
using ToysStore.Web.Models.DomainModel;

namespace ToysStore.Web.Models.ViewModel.WebUI
{
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
           //получаем объект
            Cart cart = null; 
            //получаем из сеанса
            if(controllerContext.HttpContext.Session != null)
            {
                cart = (Cart)controllerContext.HttpContext.Session[sessionKey];
            }
            //создаем объект если его не обнаружено
            if (cart == null)
            {
                cart = new Cart();
                if(controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }
            return cart;
        }
    }
}