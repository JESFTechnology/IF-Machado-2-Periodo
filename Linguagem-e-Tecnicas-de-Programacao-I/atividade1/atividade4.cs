using System;

namespace ConversaoDeTemperatura
{
    class Program
    {
        static float ConverterParaFahrenheit(float celsius)
        {
            float fahrenheit = (celsius * 9 / 5) + 32;
            return fahrenheit;
        }

        static void Main(string[] args)
        {
            Console.Write("Digite uma temperatura em Celsius: ");
            float celsius = float.Parse(Console.ReadLine());
            float fahrenheit = ConverterParaFahrenheit(celsius);
            Console.WriteLine(celsius + " graus Celsius é igual a " + fahrenheit + " graus Fahrenheit");
        }
    }
}
