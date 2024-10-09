using System;

namespace ConversaoDeTemperatura
{
    class Program
    {
        static float ConverterParaFahrenheit(float celsius)
        {
            // Converte a temperatura de Celsius para Fahrenheit
            float fahrenheit = (celsius * 9 / 5) + 32;
            return fahrenheit;
        }

        static void Main(string[] args)
        {
            // Solicita uma temperatura em Celsius ao usuário
            Console.Write("Digite uma temperatura em Celsius: ");
            float celsius = float.Parse(Console.ReadLine());

            // Chama a função ConverterParaFahrenheit e exibe o resultado
            float fahrenheit = ConverterParaFahrenheit(celsius);
            Console.WriteLine(celsius + " graus Celsius é igual a " + fahrenheit + " graus Fahrenheit");
        }
    }
}
