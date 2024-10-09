using System;

namespace CalculadoraDePotencia
{
    class Program
    {
        static double CalcularPotencia(int baseNumber, int exponent)
        {
            // Calcula a potência da base elevada ao expoente
            double result = Math.Pow(baseNumber, exponent);
            return result;
        }

        static void Main(string[] args)
        {
            // Solicita a base e o expoente ao usuário
            Console.Write("Digite a base: ");
            int baseNumber = int.Parse(Console.ReadLine());

            Console.Write("Digite o expoente: ");
            int exponent = int.Parse(Console.ReadLine());

            // Chama a função CalcularPotencia e exibe o resultado
            double result = CalcularPotencia(baseNumber, exponent);
            Console.WriteLine(baseNumber + " elevado ao " + exponent + " é igual a " + result);
        }
    }
}
