using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using System.Threading.Tasks;

namespace RefactorPizza
{
    internal class MenuUI
    {
        public static void ShowMenu<T>(string title, ResourceManager rm, Dictionary<string, T> dic)
        {
            Console.WriteLine(title);

            foreach (var ingredient in dic)
            {
                Console.WriteLine((dic.ToList().IndexOf(ingredient) + 1) +
                    ". " + rm.GetString(ingredient.Key));
            }
        }

        public static int AskNumber(string message)
        {
            bool valid;
            int number;

            do
            {
                valid = false;
                Console.Write($"{message}: ");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out number))
                {
                    valid = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Error.WriteLine("Introduce un número.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            } while (!valid);
            

            return number;
        }

        public static int AskOption(int max)
        {
            int index;
            do
            {
                index = AskNumber("Introduce una opción") - 1;

                if (index < 0 || index >= max)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Error.WriteLine("Opción inválida");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            } while (index < 0 || index >= max);
            return index;
        }
    }
}
