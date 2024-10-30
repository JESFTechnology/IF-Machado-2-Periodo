using System;

class Program
{
    static void Main()
    {
        Random random = new Random();
        
        Console.WriteLine("Digite o número de elementos a serem sorteados:");
        int n = int.Parse(Console.ReadLine());
        int[] vetor = new int[n];
        for (int i = 0; i < n; i++)
        {
            vetor[i] = random.Next(1, 101);
        }
        Console.WriteLine();

        Console.WriteLine("Digite um número para verificar se está no vetor:");
        int numero = int.Parse(Console.ReadLine());
        int posicao = -1;
        for (int i = 0; i < n; i++)
        {
            if (vetor[i] == numero)
            {
                posicao = i;
                break;
            }
        }

        if (posicao != -1)
        {
            Console.WriteLine("O número "+numero+" está no vetor na posição "+posicao+".");
        }
        else
        {
            Console.WriteLine($"O número "+numero+" não está no vetor.");
        }
    }
}
