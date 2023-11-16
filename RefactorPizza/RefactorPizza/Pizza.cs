using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorPizza
{
    public struct Pizza : IPurchasable
    {
        public static Dictionary<string, int> IngredientsPrice = new();
        public static Dictionary<string, string> SizesPrice = new();
        public string Ingredient { get; set; }
        public string Size { get; set; }

        public Pizza(string ingredient, string size)
        {
            Ingredient = ingredient;
            Size = size;
        }

        public float GetFullPrice()
        {
            return IngredientsPrice[Ingredient] *
                Convert.ToSingle(SizesPrice[Size], new CultureInfo("en-US"));
        }
    }
}
