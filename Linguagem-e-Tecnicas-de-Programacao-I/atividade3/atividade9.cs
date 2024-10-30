using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Digite o tamanho do vetor:");
        int n = int.Parse(Console.ReadLine());
        int[] vetor = new int[n];
      
        Console.WriteLine("Digite os elementos do vetor:");
      
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Elemento {i + 1}: ");
            vetor[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Digite o valor a ser buscado:");
        int valorBuscado = int.Parse(Console.ReadLine());

        int contador = 0;
        for (int i = 0; i < n; i++)
        {
            if (vetor[i] == valorBuscado)
            {
                contador++;
            }
        }

        Console.WriteLine($"O valor {valorBuscado} aparece {contador} vez(es) no vetor.");
    }
}
