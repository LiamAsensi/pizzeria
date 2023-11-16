using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorPizza
{
    public class Order : IPurchasable
    {
        public Pizza Pizza { get; set; }
        public bool Delivery { get; set; }
        public DateTime OrderDate { get; }

        public Order(Pizza pizza, bool delivery = false)
        {
            Pizza = pizza;
            Delivery = delivery;
            OrderDate = DateTime.Now;
        }

        public float GetFullPrice()
        {
            return Pizza.GetFullPrice() + (Delivery ? 2 : 0);
        }
    }
}
