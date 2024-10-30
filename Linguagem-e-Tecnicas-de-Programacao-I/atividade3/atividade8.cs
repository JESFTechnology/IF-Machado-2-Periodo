using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Digite o tamanho do vetor de caracteres:");
        int n = int.Parse(Console.ReadLine());
    
        char[] vetor = new char[n];
        Console.WriteLine("Digite os caracteres:");
        for (int i = 0; i < n; i++)
        {
            vetor[i] = Console.ReadKey().KeyChar;
            Console.Write(" ");
        }
        Console.WriteLine();
        Console.WriteLine("Vetor em ordem inversa:");
        for (int i = n - 1; i >= 0; i--)
        {
            Console.Write(vetor[i] + " ");
        }
        Console.WriteLine();
    }
}
