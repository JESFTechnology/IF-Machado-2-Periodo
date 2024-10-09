using System;

namespace Fatorial
{
    class Program
    {
        static long CalcularFatorial(int numero)
        {
            // Verifica se o número é negativo
            if (numero < 0)
            {
                throw new ArgumentException("O número deve ser um inteiro positivo.");
            }

            // Calcula o fatorial do número
            long fatorial = 1;
            for (int i = 1; i <= numero; i++)
            {
                fatorial *= i;
            }

            return fatorial;
        }

        static void Main(string[] args)
        {
            // Solicita um número ao usuário
            Console.Write("Digite um número: ");
            int numero = int.Parse(Console.ReadLine());

            // Chama a função CalcularFatorial e exibe o fatorial
            long fatorial = CalcularFatorial(numero);
            Console.WriteLine("O fatorial de " + numero + " é: " + fatorial);
        }
    }
}
