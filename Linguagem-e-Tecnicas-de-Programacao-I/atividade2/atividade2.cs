using System;

class Program
{   
    static void Main()
    {
        Console.Write("Digite o 1º texto: ");
        string texto1 = Console.ReadLine();
        
        Console.Write("Digite o 1 letra: ");
        char letra1 = Console.ReadLine()[0];
        
        texto1 = texto1.ToUpper();
        letra1 = Char.ToUpper(letra1);
        
        int count = 0;
        
        for(int x=0; x < texto1.Length; x++){
            char c = texto1[x];
            if (c == letra1)
            {
                count++;
            }
        }
        
        Console.Write("Tem "+count+" letras "+letra1+" na palavra ou texto");
    }
}
