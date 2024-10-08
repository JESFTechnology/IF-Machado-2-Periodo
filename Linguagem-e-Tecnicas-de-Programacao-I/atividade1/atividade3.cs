using System;

namespace Fatorial
{
    class Program
    {
        static long CalcularFatorial(int numero)
        {
            if (numero < 0)
            {
                return 0;
            }
            long fatorial = 1;
            for (int i = 1; i <= numero; i++)
            {
                fatorial *= i;
            }

            return fatorial;
        }

        static void Main(string[] args)
        {
            Console.Write("Digite um número: ");
            int numero = int.Parse(Console.ReadLine());
            long fatorial = CalcularFatorial(numero);
            if(numero < 0){
                Console.WriteLine("O número deve ser um inteiro positivo.");
            }else{
                Console.WriteLine("O fatorial de " + numero + " é: " + fatorial);
            }
            
        }
    }
}
