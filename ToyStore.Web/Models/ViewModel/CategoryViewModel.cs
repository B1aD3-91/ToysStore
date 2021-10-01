using System.Collections.Generic;
using ToysStore.Domain.Model;

namespace ToysStore.Web.Models.ViewModel
{
    public class CategoryViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
    }
}