using System.Collections.Generic;
using ToysStore.Web.Models.WebUI;
using ToysStore.Web.Models.DomainModel;

namespace ToysStore.Web.Models.ViewModel
{
    public class ToyViewModel
    {
        public IEnumerable<Toy> Toys { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}