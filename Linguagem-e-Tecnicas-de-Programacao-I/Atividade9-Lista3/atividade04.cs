using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CatalogoJogos
{
    class Emprestimo
    {
        public DateTime Data { get; set; }
        public string NomePessoa { get; set; }
        public char Emprestado { get; set; } // 'S' para emprestado, 'N' para não emprestado

        public override string ToString()
        {
            if (Emprestado == 'S')
            {
                return $"Emprestado para: {NomePessoa}, Data do Empréstimo: {Data.ToString("yyyy-MM-dd")}";
            }
            return "Disponível";
        }

        public static Emprestimo FromString(string data)
        {
            var parts = data.Split(';');
            return new Emprestimo
            {
                Data = DateTime.Parse(parts[0]),
                NomePessoa = parts[1],
                Emprestado = char.Parse(parts[2])
            };
        }
    }

    class Jogo
    {
        public string Titulo { get; set; }
        public string Console { get; set; }
        public int Ano { get; set; }
        public int Ranking { get; set; }
        public Emprestimo Emprestimo { get; set; }

        public Jogo(string titulo, string console, int ano, int ranking)
        {
            Titulo = titulo;
            Console = console;
            Ano = ano;
            Ranking = ranking;
            Emprestimo = new Emprestimo { Emprestado = 'N' };
        }

        public override string ToString()
        {
            return $"Título: {Titulo}, Console: {Console}, Ano: {Ano}, Ranking: {Ranking}, Status: {Emprestimo}";
        }

        public static Jogo FromString(string data)
        {
            var parts = data.Split(';');
            return new Jogo(parts[0], parts[1], int.Parse(parts[2]), int.Parse(parts[3]))
            {
                Emprestimo = Emprestimo.FromString(string.Join(";", parts.Skip(4)))
            };
        }
    }

    class Program
    {
        static List<Jogo> jogos = new List<Jogo>();
        const string caminhoArquivo = "dados.txt";

        static void Main(string[] args)
        {
            CarregarDados();

            int opcao;
            do
            {
                Console.WriteLine("1. Cadastrar Jogo");
                Console.WriteLine("2. Procurar Jogo por Título");
                Console.WriteLine("3. Listar Jogos por Console");
                Console.WriteLine("4. Realizar Empréstimo");
                Console.WriteLine("5. Devolver Jogo");
                Console.WriteLine("6. Mostrar Jogos Emprestados");
                Console.WriteLine("7. Salvar Dados");
                Console.WriteLine("8. Sair");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CadastrarJogo();
                        break;
                    case 2:
                        ProcurarJogoPorTitulo();
                        break;
                    case 3:
                        ListarJogosPorConsole();
                        break;
                    case 4:
                        RealizarEmprestimo();
                        break;
                    case 5:
                        DevolverJogo();
                        break;
                    case 6:
                        MostrarJogosEmprestados();
                        break;
                    case 7:
                        SalvarDados();
                        break;
                    case 8:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            } while (opcao != 8);
        }

        static void CadastrarJogo()
        {
            Console.Write("Título: ");
            string titulo = Console.ReadLine();

            Console.Write("Console: ");
            string console = Console.ReadLine();

            Console.Write("Ano: ");
            int ano = int.Parse(Console.ReadLine());

            Console.Write("Ranking: ");
            int ranking = int.Parse(Console.ReadLine());

            Jogo jogo = new Jogo(titulo, console, ano, ranking);
            jogos.Add(jogo);

            Console.WriteLine("Jogo cadastrado com sucesso!");
        }

        static void ProcurarJogoPorTitulo()
        {
            Console.Write("Digite o título do jogo a ser procurado: ");
            string titulo = Console.ReadLine();

            var jogo = jogos.FirstOrDefault(j => j.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

            if (jogo != null)
            {
                Console.WriteLine(jogo);
            }
            else
            {
                Console.WriteLine("Jogo não encontrado.");
            }
        }

        static void ListarJogosPorConsole()
        {
            Console.Write("Digite o console: ");
            string console = Console.ReadLine();

            var jogosPorConsole = jogos.Where(j => j.Console.Equals(console, StringComparison.OrdinalIgnoreCase)).ToList();

            if (jogosPorConsole.Count > 0)
            {
                foreach (var jogo in jogosPorConsole)
                {
                    Console.WriteLine(jogo);
                }
            }
            else
            {
                Console.WriteLine("Nenhum jogo encontrado para este console.");
            }
        }

        static void RealizarEmprestimo()
        {
            Console.Write("Digite o título do jogo a ser emprestado: ");
            string titulo = Console.ReadLine();

            var jogo = jogos.FirstOrDefault(j => j.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

            if (jogo != null && jogo.Emprestimo.Emprestado == 'N')
            {
                Console.Write("Digite o nome da pessoa: ");
                string nomePessoa = Console.ReadLine();

                jogo.Emprestimo.Data = DateTime.Now;
                jogo.Emprestimo.NomePessoa = nomePessoa;
                jogo.Emprestimo.Emprestado = 'S';

                Console.WriteLine("Empréstimo realizado com sucesso!");
            }
            else if (jogo != null)
            {
                Console.WriteLine("O jogo já está emprestado.");
            }
            else
            {
                Console.WriteLine("Jogo não encontrado.");
            }
        }

        static void DevolverJogo()
        {
            Console.Write("Digite o título do jogo a ser devolvido: ");
            string titulo = Console.ReadLine();

            var jogo = jogos.FirstOrDefault(j => j.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

            if (jogo != null && jogo.Emprestimo.Emprestado == 'S')
            {
                jogo.Emprestimo.Emprestado = 'N';
                jogo.Emprestimo.NomePessoa = string.Empty;
                jogo.Emprestimo.Data = DateTime.MinValue;

                Console.WriteLine("Jogo devolvido com sucesso!");
            }
            else if (jogo != null)
            {
                Console.WriteLine("O jogo não está emprestado.");
            }
            else
            {
                Console.WriteLine("Jogo não encontrado.");
            }
        }

        static void MostrarJogosEmprestados()
        {
            var jogosEmprestados = jogos.Where(j => j.Emprestimo.Emprestado == 'S').ToList();

            if (jogosEmprestados.Count > 0)
            {
                foreach (var jogo in jogosEmprestados)
                {
                    Console.WriteLine($"Título: {jogo.Titulo}, Emprestado para: {jogo.Emprestimo.NomePessoa}, Data do Empréstimo: {jogo.Emprestimo.Data}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum jogo está emprestado no momento.");
            }
        }

        static void SalvarDados()
        {
            using (StreamWriter writer = new StreamWriter(caminhoArquivo))
            {
                foreach (var jogo in jogos)
                {
                    writer.WriteLine(jogo);
                }
            }
            Console.WriteLine("Dados salvos com sucesso!");
        }

        static void CarregarDados()
        {
            if (File.Exists(caminhoArquivo))
            {
                using (StreamReader reader = new StreamReader(caminhoArquivo))
                {
                    string linha;
                    while ((linha = reader.ReadLine()) != null)
                    {
                        jogos.Add(Jogo.FromString(linha));
                    }
                }
                Console.WriteLine("Dados carregados com sucesso!");
            }
            else
            {
                Console.WriteLine("Arquivo de dados não encontrado. Nenhum dado foi carregado.");
            }
        }
    }
}
