using System;

class Program
{
    static int ContarI(int[] vetor)
    {
        int contador = 0;
        for (int i = 0; i < vetor.Length; i++)
        {
            if (vetor[i] % 2 != 0)
            {
                contador++;
            }
        }
        return contador;
    }
    
    static void Main()
    {
        Console.WriteLine("Digite o número de elementos do vetor:");
        int n = int.Parse(Console.ReadLine());
        int[] vetor = new int[n];
        Console.WriteLine("Digite "+n+" números inteiros:");
        for (int i = 0; i < n; i++)
        {
            vetor[i] = int.Parse(Console.ReadLine());
        }
        int quantidadeImpares = ContarI(vetor);
        Console.WriteLine("Quantidade de números ímpares no vetor: "+quantidadeImpares);
    }
}
