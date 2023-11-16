using System.Globalization;
using System.Resources;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace RefactorPizza
{
    public class Program
    {
        public static readonly string INGREDIENTS_JSON = "Resources/Data/ingredients.json";
        public static readonly string SIZES_JSON = "Resources/Data/sizes.json";
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Load();

            MenuUI.ShowMenu(
                "INGREDIENTES", 
                new ResourceManager("RefactorPizza.Resources.Strings.Ingredients", typeof(Program).Assembly),
                Pizza.IngredientsPrice
            );
            int ingredientIndex = MenuUI.AskOption(Pizza.IngredientsPrice.Count);

            Console.WriteLine();

            MenuUI.ShowMenu(
                "TAMAÑOS",
                new ResourceManager("RefactorPizza.Resources.Strings.Sizes", typeof(Program).Assembly),
                Pizza.SizesPrice
            );
            int sizesIndex = MenuUI.AskOption(Pizza.SizesPrice.Count);

            Console.WriteLine("\n¿Es un pedido a domicilio?\n1. Si\n2. No");
            int delivery = MenuUI.AskOption(2);

            Pizza pizza = new (Pizza.IngredientsPrice.ElementAt(ingredientIndex).Key,
                Pizza.SizesPrice.ElementAt(sizesIndex).Key);

            Order order = new(pizza, delivery == 0);

            Console.WriteLine($"\nPrecio de la pizza: {order.GetFullPrice():F2}€");
        }

        public static void Load()
        {
            Pizza.IngredientsPrice = JsonManager.JsonToDictionary<string, int>(INGREDIENTS_JSON);
            Pizza.SizesPrice = JsonManager.JsonToDictionary<string, string>(SIZES_JSON);
        }
    }
}