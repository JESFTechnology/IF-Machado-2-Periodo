using System;

namespace NumeroPrimo
{
    class Program
    {
        static string EhPrimo(int numero)
        {
            // Verifica se o número é menor que 2
            if (numero < 2)
            {
                return "Não!";
            }

            // Verifica se o número é primo
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
            // Solicita um número ao usuário
            Console.Write("Digite um número: ");
            int numero = int.Parse(Console.ReadLine());

            // Chama a função EhPrimo e exibe se o número é primo
            string ehPrimo = EhPrimo(numero);
            Console.WriteLine("O número " + numero + " é primo? " + ehPrimo);
        }
    }
}
