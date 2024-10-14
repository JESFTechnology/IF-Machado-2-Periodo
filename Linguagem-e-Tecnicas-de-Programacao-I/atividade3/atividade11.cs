using System;
class TxtoCriptografado {
  static void Main() {
    Console.Write("Digite o texto criptografado: ");
    string texto = Console.ReadLine();
    string newText = "";
    for(int x = 0; x < texto.Length; x++){
        if(texto[x] != 'p'){
            newText += texto[x];
        }
    }
    Console.Write("\n------------------------------\n\n");
    Console.Write("Texto descriptografado: ");
    Console.Write(newText);
  }
}
