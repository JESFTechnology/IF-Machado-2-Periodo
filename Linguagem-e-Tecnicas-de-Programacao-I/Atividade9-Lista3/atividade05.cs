using System;
using System.Collections.Generic;
using System.Linq; 

class DataNascimento
{
    public int Mes { get; set; }
    public int Ano { get; set; }
}

class Bicho
{
    public int Id { get; set; }
    public int QuantidadeLeite { get; set; }
    public int QuantidadeAlimento { get; set; }
    public DataNascimento DataNasc { get; set; }
    public string StatusAbate { get; set; }
}

static class FazendaPrograma
{
    static List<Bicho> ObterDados()
    {
        List<Bicho> bichos = new List<Bicho>();
        // Simulação de leitura de dados
        bichos.Add(new Bicho { Id = 1, QuantidadeLeite = 50, QuantidadeAlimento = 30, DataNasc = new DataNascimento { Mes = 5, Ano = 2018 }, StatusAbate = "N" });
        bichos.Add(new Bicho { Id = 2, QuantidadeLeite = 30, QuantidadeAlimento = 25, DataNasc = new DataNascimento { Mes = 7, Ano = 2017 }, StatusAbate = "N" });
        return bichos;
    }

    static void AtualizarCampoAbate(List<Bicho> bichos)
    {
        foreach (var bicho in bichos)
        {
            int idade = DateTime.Now.Year - bicho.DataNasc.Ano;
            if (idade > 5 || bicho.QuantidadeLeite < 40)
            {
                bicho.StatusAbate = "S";
            }
            else
            {
                bicho.StatusAbate = "N";
            }
        }
    }

    static int TotalLeiteProduzido(List<Bicho> bichos)
    {
        return bichos.Sum(bicho => bicho.QuantidadeLeite);
    }

    static int TotalAlimentoConsumido(List<Bicho> bichos)
    {
        return bichos.Sum(bicho => bicho.QuantidadeAlimento);
    }

    static void ListarBichosParaAbate(List<Bicho> bichos)
    {
        foreach (var bicho in bichos.Where(b => b.StatusAbate == "S"))
        {
            Console.WriteLine($"Bicho {bicho.Id} deve ir para o abate.");
        }
    }

    static void SalvarDados(List<Bicho> bichos, string caminho)
    {
        using (var sw = new System.IO.StreamWriter(caminho))
        {
            foreach (var bicho in bichos)
            {
                sw.WriteLine($"{bicho.Id},{bicho.QuantidadeLeite},{bicho.QuantidadeAlimento},{bicho.DataNasc.Mes},{bicho.DataNasc.Ano},{bicho.StatusAbate}");
            }
        }
    }

    static List<Bicho> CarregarDados(string caminho)
    {
        var bichos = new List<Bicho>();
        var linhas = System.IO.File.ReadAllLines(caminho);

        foreach (var linha in linhas)
        {
            var dados = linha.Split(',');
            var dataNasc = new DataNascimento { Mes = int.Parse(dados[3]), Ano = int.Parse(dados[4]) };
            bichos.Add(new Bicho
            {
                Id = int.Parse(dados[0]),
                QuantidadeLeite = int.Parse(dados[1]),
                QuantidadeAlimento = int.Parse(dados[2]),
                DataNasc = dataNasc,
                StatusAbate = dados[5]
            });
        }
        return bichos;
    }

    static void Sair()
    {
        Console.WriteLine("Saindo do programa...");
    }

    static void Menu()
    {
        List<Bicho> bichos = new List<Bicho>();
        int opcao;
        do
        {
            Console.WriteLine("1. Ler dados");
            Console.WriteLine("2. Preencher campo abate");
            Console.WriteLine("3. Total de leite produzido");
            Console.WriteLine("4. Total de alimento consumido");
            Console.WriteLine("5. Listar bichos para abate");
            Console.WriteLine("6. Salvar dados");
            Console.WriteLine("7. Carregar dados");
            Console.WriteLine("8. Sair");
            Console.WriteLine("Digite a opção desejada:");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    bichos = ObterDados();
                    Console.WriteLine("Dados lidos com sucesso.");
                    break;
                case 2:
                    AtualizarCampoAbate(bichos);
                    Console.WriteLine("Campo abate preenchido.");
                    break;
                case 3:
                    Console.WriteLine($"Total de leite produzido: {TotalLeiteProduzido(bichos)} litros");
                    break;
                case 4:
                    Console.WriteLine($"Total de alimento consumido: {TotalAlimentoConsumido(bichos)} kg");
                    break;
                case 5:
                    ListarBichosParaAbate(bichos);
                    break;
                case 6:
                    Console.Write("Nome do arquivo para salvar: ");
                    string arquivoSalvar = Console.ReadLine();
                    SalvarDados(bichos, arquivoSalvar);
                    Console.WriteLine("Dados salvos com sucesso.");
                    break;
                case 7:
                    Console.Write("Nome do arquivo para carregar: ");
                    string arquivoCarregar = Console.ReadLine();
                    bichos = CarregarDados(arquivoCarregar);
                    Console.WriteLine("Dados carregados com sucesso.");
                    break;
                case 8:
                    Sair();
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        } while (opcao != 8);
    }

    static void Main(string[] args)
    {
        Menu();
    }
}
