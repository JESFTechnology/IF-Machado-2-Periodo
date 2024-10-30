using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Digite o número de lançamentos:");
        int n = int.Parse(Console.ReadLine());

        int[] resultados = new int[n];

        Console.WriteLine("Digite os resultados dos lançamentos (números de 1 a 6):");
        for (int i = 0; i < n; i++)
        {
            resultados[i] = int.Parse(Console.ReadLine());
        }

        int[] contagem = new int[6];
        for (int i = 0; i < n; i++)
        {
            if (resultados[i] >= 1 && resultados[i] <= 6)
            {
                contagem[resultados[i] - 1]++;
            }
        }

        Console.WriteLine("Ocorrências de cada face:");
        for (int i = 0; i < 6; i++)
        {
            Console.WriteLine($"Face {i + 1}: {contagem[i]}");
        }
    }
}
