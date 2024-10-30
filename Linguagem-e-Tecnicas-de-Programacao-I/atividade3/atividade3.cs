using System;

class Program
{
    static double MenorE(double[] v)
    {
        double m = v[0];
        for (int i = 1; i < v.Length; i++)
        {
            if (v[i] < m)
            {
                m = v[i];
            }
        }
        return m;
    }
    static void Main()
    {
        Console.WriteLine("Digite o número de elementos do vetor:");
        int n = int.Parse(Console.ReadLine());

        double[] vetor = new double[n];

        Console.WriteLine("Digite "+n+" números reais:");

        for (int i = 0; i < n; i++)
        {
            vetor[i] = double.Parse(Console.ReadLine());
        }

        double menor = MenorE(vetor);
        Console.WriteLine("Menor elemento: " + menor);
    }
}
