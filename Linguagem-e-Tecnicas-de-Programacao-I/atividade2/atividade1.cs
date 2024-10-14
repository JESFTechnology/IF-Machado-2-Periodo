using System;

class Program
{
    static void Main()
    {
        Console.Write("Digite o 1º texto: ");
        string texto1 = Console.ReadLine();

        Console.Write("Digite o 2º texto: ");
        string texto2 = Console.ReadLine();
      
        string texto1Maiusculo = texto1.ToUpper();
        string texto2Maiusculo = texto2.ToUpper();

        if (string.Compare(texto1Maiusculo, texto2Maiusculo) == 0)
        {
            Console.WriteLine("Os textos são iguais.");
        }
        else
        {
            Console.WriteLine("Os textos são diferentes.");
        }

        Console.WriteLine($"O primeiro texto tem {texto1.Length} caracteres.");
        Console.WriteLine($"O segundo texto tem {texto2.Length} caracteres.");
    }
}
