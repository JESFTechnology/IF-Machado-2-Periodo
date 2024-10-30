using System;

class Program
{
    static char OBC(char baseDna)
    {
        switch (baseDna)
        {
            case 'A':
                return 'T';
            case 'T':
                return 'A';
            case 'C':
                return 'G';
            case 'G':
                return 'C';
            default:
                return ' ';
        }
    }
    
    static void Main()
    {
        char[] dna = new char[50];
        int tamanho = 0;
        Console.WriteLine("Digite a fita de DNA (até 50 caracteres, apenas A, T, C, G):");
        string entrada = Console.ReadLine();

        while (tamanho < entrada.Length && tamanho < 50)
        {
            char baseDna = entrada[tamanho];

            if (baseDna == 'A' || baseDna == 'T' || baseDna == 'C' || baseDna == 'G')
            {
                dna[tamanho] = baseDna;
                tamanho++;
            }
            else
            {
                Console.WriteLine("Apenas A, T, C e G são permitidos.");
                return;
            }
        }

        char[] dnaC = new char[tamanho];
        for (int i = 0; i < tamanho; i++)
        {
            dnaC[i] = OBC(dna[i]);
        }

        Console.WriteLine("Fita de DNA: " + new string(dna, 0, tamanho));
        Console.WriteLine("Fita comple: " + new string(dnaC));
    }
}
