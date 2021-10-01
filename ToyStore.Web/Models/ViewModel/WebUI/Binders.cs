using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

namespace ToysStore.Web.Models.ViewModel.WebUI
{
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";
        private readonly IModelBinder fallbackBinder;

        public CartModelBinder(IModelBinder fallbackBinder)
        {
            this.fallbackBinder = fallbackBinder;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var cart = bindingContext.ValueProvider.GetValue(sessionKey);
            
            if (cart == ValueProviderResult.None)
                return fallbackBinder.BindModelAsync(bindingContext);

            bindingContext.Result = ModelBindingResult.Success(cart);

            return Task.CompletedTask;
        }
    }
}
