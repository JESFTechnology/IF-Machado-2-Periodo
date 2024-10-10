using System;

namespace CalculadoraDePotencia
{
    class Program
    {
        static double CalcularPotencia(int baseNumber, int exponent)
        {
            double result = baseNumber;
            for(int i = 1; i < exponent; i++ ){
                result = result * baseNumber;
            }
            return result;
        }

        static void Main(string[] args)
        {
            Console.Write("Digite a base: ");
            int baseNumber = int.Parse(Console.ReadLine());
            Console.Write("Digite o expoente: ");
            int exponent = int.Parse(Console.ReadLine());
            double result = CalcularPotencia(baseNumber, exponent);
            Console.WriteLine(baseNumber + " elevado ao " + exponent + " é igual a " + result);
        }
    }
}
