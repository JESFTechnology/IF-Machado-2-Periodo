using System;

namespace MediaAritmetica
{
    class Program
    {
        static float CalcularMedia(float num1, float num2, float num3)
        {
            float media = (num1 + num2 + num3) / 3;
            return media;
        }

        static void Main(string[] args)
        {
            Console.Write("Digite o primeiro número: ");
            float num1 = float.Parse(Console.ReadLine());

            Console.Write("Digite o segundo número: ");
            float num2 = float.Parse(Console.ReadLine());

            Console.Write("Digite o terceiro número: ");
            float num3 = float.Parse(Console.ReadLine());

            float media = CalcularMedia(num1, num2, num3);
            Console.WriteLine("A média aritmética é: " + media);
        }
    }
}
