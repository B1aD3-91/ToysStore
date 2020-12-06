using System.Collections.Generic;
using ToysStore.Web.Models.DomainModel;

namespace ToysStore.Web.Models.ViewModel
{
    public class CategoryViewModel
    {
        public IEnumerable<ToyCategory> Categories { get; set; }
    }
}