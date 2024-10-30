using System;

class Program
{
    static double MaiorE(double[] v)
    {
        double m = v[0];
        for (int i = 1; i < v.Length; i++)
        {
            if (v[i] > m)
            {
                m = v[i];
            }
        }
        return m;
    }

    static void Main(string[] args)
    {
        Console.Write("Informe a quantidade de elementos do vetor: ");
        int n = int.Parse(Console.ReadLine());
        double[] vetor = new double[n];
        
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Informe o elemento do valor {i + 1}: ");
            vetor[i] = double.Parse(Console.ReadLine());
        }
        
        Console.WriteLine("O vetor é: [" + string.Join(", ", vetor) + "]");
        double maior = MaiorE(vetor);
        Console.WriteLine($"O maior elemento do vetor é: {maior}");
    }
}
