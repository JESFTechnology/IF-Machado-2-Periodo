using System;
using System.Drawing;
using System.IO;
class Eletrodomestico
{
    public string nome;
    public double potencia;
    public double tempoAtivo;
}
class Program
{
    static void addEletrodomestico(List<Eletrodomestico> listadeEletrodomestico)
    {
        Eletrodomestico novoEletrodomestico = new Eletrodomestico();
        Console.WriteLine("*** Dados para Eletrodomésticos  ***");
        Console.Write("Nome:");
        novoEletrodomestico.nome = Console.ReadLine();
        Console.Write("Potência em KW:");
        novoEletrodomestico.potencia = double.Parse(Console.ReadLine());
        Console.Write("Tempo médio ativo por dia:");
        novoEletrodomestico.tempoAtivo = double.Parse(Console.ReadLine());
        listadeEletrodomestico.Add(novoEletrodomestico);
        Console.WriteLine("Dados adicionados com sucesso!");
    }

    static void listarEletrodomesticos(List<Eletrodomestico> listaEletrodomesticos)
    {
        Console.WriteLine("*** Eletrodomésticos Cadastrados ***");
        foreach (var eletro in listaEletrodomesticos)
        {
            Console.WriteLine($"Nome: {eletro.nome}, Potência: {eletro.potencia} kW, Tempo Ativo: {eletro.tempoAtivo} horas");
        }
    }

    static void buscarEletrodomestico(List<Eletrodomestico> listaEletrodomesticos, string nomeBusca)
    {
        foreach (var eletro in listaEletrodomesticos)
        {
            if (eletro.nome.Equals(nomeBusca, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Eletrodoméstico encontrado: Nome: {eletro.nome}, Potência: {eletro.potencia} kW, Tempo Ativo: {eletro.tempoAtivo} horas");
                return;
            }
        }
        Console.WriteLine("Eletrodoméstico não encontrado.");
    }

    static void buscarPorConsumo(List<Eletrodomestico> listaEletrodomesticos, double consumoMinimo, double valor)
    {
        Console.WriteLine($"Eletrodomésticos que consomem mais que {consumoMinimo} kW:");
        double valorFinal = 0;
        foreach (var eletro in listaEletrodomesticos)
        {
            double consumoDiario = eletro.potencia * eletro.tempoAtivo;
            if (consumoDiario > consumoMinimo)
            {
                valorFinal += consumoDiario * valor;
                Console.WriteLine($"Nome: {eletro.nome}, Consumo Diário: {consumoDiario} kW");
                Console.WriteLine($"Valor do consumo R${consumoDiario * valor}");
            }
        }
        Console.WriteLine($"Valor final de todos os consumos R${valorFinal}");
    }

    static void salvarDados(List<Eletrodomestico> listadeEletrodomestico, string nomeArquivo)
    {
        StreamWriter writer = new StreamWriter(nomeArquivo);

        foreach (Eletrodomestico eletrodomestico in listadeEletrodomestico)
        {
            writer.WriteLine($"{eletrodomestico.nome},{eletrodomestico.potencia},{eletrodomestico.tempoAtivo}");
        }

        Console.WriteLine("Dados salvos com sucesso!");
        writer.Dispose();
    }



    static void carregarDados(List<Eletrodomestico> listadeEletrodomestico, string nomeArquivo)
    {
        if (File.Exists(nomeArquivo))
        {
            string[] linhas = File.ReadAllLines(nomeArquivo);
            foreach (string linha in linhas)
            {
                string[] campos = linha.Split(',');
                Eletrodomestico eletrodomestico = new Eletrodomestico();
                eletrodomestico.nome = campos[0];
                eletrodomestico.potencia = double.Parse(campos[1]);
                eletrodomestico.tempoAtivo = double.Parse(campos[2]);
                listadeEletrodomestico.Add(eletrodomestico);
            }
            Console.WriteLine("Dados carregados com sucesso!");
        }
        else
        {
            Console.WriteLine("Arquivo não encontrado :(");
        }
    }

    static int menu()
    {
        Console.WriteLine("*** Sistema de Cadastro Eletrodomestico ***");
        Console.WriteLine("1-Inserir");
        Console.WriteLine("2-Mostrar");
        Console.WriteLine("3-Busca por nome");
        Console.WriteLine("4-Busca por valor gasto acima de...");
        Console.WriteLine("0-Sair");
        int op = int.Parse(Console.ReadLine());
        return op;
    }
    static void Main()
    {
        List<Eletrodomestico> listadeEletrodomestico = new List<Eletrodomestico>();
        int op;
        carregarDados(listadeEletrodomestico, "dados.txt");
        do
        {
            op = menu();
            switch (op)
            {
                case 1:
                    addEletrodomestico(listadeEletrodomestico);
                    break;
                case 2:
                    listarEletrodomesticos(listadeEletrodomestico);
                    break;
                case 3:
                    Console.WriteLine("Pesquisa por nome. Digite o nome do eletrodomestico:");
                    string eletrodomesticoNome = Console.ReadLine();
                    buscarEletrodomestico(listadeEletrodomestico, eletrodomesticoNome);
                    break;
                case 4:
                    Console.WriteLine("Pesquisa por consumo. Digite o valor em Kw:");
                    double consumo = double.Parse(Console.ReadLine());;
                    Console.WriteLine("Agora insira o valor do Kw/h:");
                    double val = double.Parse(Console.ReadLine()); ;
                    buscarPorConsumo(listadeEletrodomestico, consumo, val);
                    break;
                case 0:
                    Console.WriteLine("Saindo...");
                    salvarDados(listadeEletrodomestico, "dados.txt");
                    break;
            }// fim switch
            Console.ReadKey(); // pausa
            Console.Clear(); // limpa tela
        } while (op != 0);


    }// fim main

}
