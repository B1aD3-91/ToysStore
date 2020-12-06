using System.Collections.Generic;
using System.Linq;

namespace ToysStore.Web.Models.DomainModel
{
    public class CardList
    {
        public Toy Toy { get; set; }
        public int Quantity { get; set; }
    }

    public class Cart
    {
        private List<CardList> cardCollections = new List<CardList>();

        public void AddItem(Toy toy, int quantity)
        {
            CardList List = cardCollections.Where(x => x.Toy.Id == toy.Id).FirstOrDefault();

            if (List == null)
            {
                cardCollections.Add(new CardList { Toy = toy, Quantity = quantity });
            }
            else
            {
                List.Quantity += quantity;
            }
        }
        public void RemoveList(Toy toy)
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