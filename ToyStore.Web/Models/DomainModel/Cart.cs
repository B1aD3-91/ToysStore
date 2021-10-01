using System.Collections.Generic;
using System.Linq;

using ToysStore.Domain.Model;

namespace ToysStore.Web.Models.DomainModel
{
    public class CardList
    {
        public Product Toy { get; set; }
        public int Quantity { get; set; }
    }

    public class Cart
    {
        private List<CardList> cardCollections = new List<CardList>();

        public void AddItem(Product toy, int quantity)
        {
            CardList list = cardCollections.Where(x => x.Toy.Id == toy.Id).FirstOrDefault();

            if (list == null)
            {
                cardCollections.Add(new CardList { Toy = toy, Quantity = quantity });
            }
            else
            {
                list.Quantity += quantity;
            }
        }
        public void RemoveList(Product toy)
        {
            cardCollections.RemoveAll(x => x.Toy.Id == toy.Id);
        }
        public decimal ComputeTotalPrice()
        {
            return cardCollections.Sum(x => x.Toy.Price * x.Quantity);
        }
        public void Clear()
        {
            cardCollections.Clear();
        }
        public IEnumerable<CardList> ListItem
        {
            get { return cardCollections; }
        }

    }
}