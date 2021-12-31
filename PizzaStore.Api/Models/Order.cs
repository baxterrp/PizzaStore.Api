using System.Collections.Generic;
using System.Linq;

namespace PizzaStore.Api.Models
{
    public class Order
    {
        public string Id { get; set; }
        public IEnumerable<Topping> Toppings { get; set; }

        public decimal Total
        {
            get
            {
                return 10m + Toppings?.Sum(t => t.Price) ?? decimal.Zero;
            }
        }
    }
}
