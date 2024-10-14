using System;
class TxtoCriptografado {
  static void Main() {
    Console.Write("Digite o texto criptografado: ");
    string texto = Console.ReadLine();
    string newText = "";
    for(int x = 0; x < texto.Length; x++){
        int y = x+1;
        int z = x+2;
        if(texto[x] != 'p' || (texto[x] == 'p' && texto[y] == 'p' && texto[z] == 'p')){
            newText += texto[x];
        }
    }
    Console.Write("\n------------------------------\n\n");
    Console.Write("Texto descriptografado: ");
    Console.Write(newText);
  }
}
