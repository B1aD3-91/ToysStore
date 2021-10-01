using System.Collections.Generic;
using ToysStore.Domain.Model;
using ToysStore.Web.Models.WebUI;

namespace ToysStore.Web.Models.ViewModel
{
    public class ToyViewModel
    {
        public IEnumerable<Product> Toys { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}