using ToysStore.Web.Models.DomainModel;

namespace ToysStore.Web.Models.ViewModel
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}