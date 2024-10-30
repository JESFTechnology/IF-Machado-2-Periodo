using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Digite o número de elementos dos vetores:");
        int n = int.Parse(Console.ReadLine());

        int[] v1 = new int[n];
        int[] v2 = new int[n];
        int[] vR = new int[n];

        Console.WriteLine("Digite os elementos do primeiro vetor:");
        for (int i = 0; i < n; i++)
        {
            Console.Write("Elemento "+(i+1)+": ");
            v1[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Digite os elementos do segundo vetor:");
        for (int i = 0; i < n; i++)
        {
            Console.Write("Elemento "+(i+1)+": ");
            v2[i] = int.Parse(Console.ReadLine());
        }
        
        for (int i = 0; i < n; i++)
        {
            vR[i] = v1[i] * v2[i];
        }

        Console.WriteLine("Vetor resultante da multiplicação:");
        for (int i = 0; i < n; i++)
        {
            Console.Write(vR[i] + " ");
        }
    }
}
