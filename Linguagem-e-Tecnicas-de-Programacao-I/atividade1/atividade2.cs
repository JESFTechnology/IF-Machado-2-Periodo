using System;

namespace NumeroPrimo
{
    class Program
    {
        static string EhPrimo(int numero)
        {
            if (numero < 2)
            {
                return "Não!";
            }
            for (int i = 2; i * i <= numero; i++)
            {
                if (numero % i == 0)
                {
                    return "Não!";
                }
            }

            return "É!";
        }

        static void Main(string[] args)
        {
            Console.Write("Digite um número: ");
            int numero = int.Parse(Console.ReadLine());

            string ehPrimo = EhPrimo(numero);
            Console.WriteLine("O número " + numero + " é primo? " + ehPrimo);
        }
    }
}
