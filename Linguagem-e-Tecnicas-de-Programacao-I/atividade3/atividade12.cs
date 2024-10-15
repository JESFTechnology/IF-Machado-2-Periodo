using System;
class Carnaval {
    
    static void conferirNotas(string s){
        string newT = "";
        double[] nota = new double[5];
        int z = 0;
        for(int x = 0; x < s.Length; x++){
            if(s[x] == ' '){
                nota[z] = double.Parse(newT);
                z++;
                newT = "";
            }else{
                newT += s[x];
                if((x+1) == (s.Length)){
                    Console.WriteLine("Save");
                    nota[z] = double.Parse(newT);
                    z++;
                    newT = "";
                }
            }
        }
        Console.WriteLine(nota.Length);
    }   
    
    static void Main() {
        Console.WriteLine("Insira as notas em uma única linha: ");
        Console.WriteLine("6.4 8.2 8.2 7.4 9.1");
        string notas = "6.4 8.2 8.2 7.4 9.1";
        conferirNotas(notas);
    }
}
