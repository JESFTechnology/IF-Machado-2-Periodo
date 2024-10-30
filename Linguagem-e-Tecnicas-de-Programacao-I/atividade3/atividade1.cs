using System;

class Program
{
    static int SomaE(int[] vetor)
    {
        int soma = 0;
        foreach (int elemento in vetor)
        {
            soma += elemento;
        }
        return soma;
    }
    static void Main(string[] args)
    {
        Console.Write("Informe o número de elementos do vetor: ");
        int N = int.Parse(Console.ReadLine());
        int[] vetor = new int[N];
        for (int i = 0; i < N; i++)
        {
            Console.Write($"Informe o valor de {i + 1}: ");
            vetor[i] = int.Parse(Console.ReadLine());
        }
        int soma = SomaE(vetor);
        Console.WriteLine($"A soma dos valores do vetor é: {soma}");
    }
}
