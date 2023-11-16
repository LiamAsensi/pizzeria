using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RefactorPizza
{
    internal class JsonManager
    {
        public static Dictionary<T, E> JsonToDictionary<T, E>(string jsonPath)
            where T : IConvertible
            where E : IConvertible
        {
            Dictionary<T, E> dict = new();

            try
            {
                string jsonText = File.ReadAllText(jsonPath);

                JsonDocument ingredients = JsonDocument.Parse(jsonText);

                foreach (var property in ingredients.RootElement.EnumerateObject())
                {
                    T key = (T)Convert.ChangeType(property.Name.ToString(), typeof(T));
                    E value = (E)Convert.ChangeType(property.Value.ToString(), typeof(E));

                    dict.Add(key, value);
                }
            }
            catch (IOException ioe)
            {
                Console.Error.WriteLine("Error abriendo el archivo: " + ioe.Message);
            }
            catch (InvalidCastException ice) 
            {
                Console.Error.WriteLine("Error en la conversión de tipos: " + ice.Message);
            }
            catch (FormatException fe)
            {
                Console.Error.WriteLine("Formato inválido: " + fe.Message);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Error: " + e.Message);
            }

            return dict;
        }
    }
}
