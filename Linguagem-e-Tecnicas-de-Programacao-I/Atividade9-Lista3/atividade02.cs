using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Biblioteca
{
    struct Livro
    {
        public string Titulo;
        public string Autor;
        public int Ano;
        public string Prateleira;

        public Livro(string titulo, string autor, int ano, string prateleira)
        {
            Titulo = titulo;
            Autor = autor;
            Ano = ano;
            Prateleira = prateleira;
        }
    }

    class Program
    {
        static List<Livro> livros = new List<Livro>();
        const string caminhoArquivo = "dados.txt";

        static void Main(string[] args)
        {
            CarregarDados();

            int opcao;
            do
            {
                Console.WriteLine("1. Cadastrar Livro");
                Console.WriteLine("2. Procurar Livro por Título");
                Console.WriteLine("3. Mostrar Todos os Livros");
                Console.WriteLine("4. Mostrar Livros Mais Novos que um Ano");
                Console.WriteLine("5. Salvar Dados");
                Console.WriteLine("6. Sair");
                Console.Write("Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CadastrarLivro();
                        break;
                    case 2:
                        ProcurarLivroPorTitulo();
                        break;
                    case 3:
                        MostrarTodosLivros();
                        break;
                    case 4:
                        MostrarLivrosMaisNovosQueAno();
                        break;
                    case 5:
                        SalvarDados();
                        break;
                    case 6:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            } while (opcao != 6);
        }

        static void CadastrarLivro()
        {
            Console.Write("Título: ");
            string titulo = Console.ReadLine();

            Console.Write("Autor: ");
            string autor = Console.ReadLine();

            Console.Write("Ano: ");
            int ano = int.Parse(Console.ReadLine());

            Console.Write("Prateleira: ");
            string prateleira = Console.ReadLine();

            Livro livro = new Livro(titulo, autor, ano, prateleira);
            livros.Add(livro);

            Console.WriteLine("Livro cadastrado com sucesso!");
        }

        static void ProcurarLivroPorTitulo()
        {
            Console.Write("Digite o título do livro a ser procurado: ");
            string titulo = Console.ReadLine();

            var livro = livros.FirstOrDefault(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(livro.Titulo))
            {
                Console.WriteLine($"Livro encontrado: {livro.Titulo}, Prateleira: {livro.Prateleira}");
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        static void MostrarTodosLivros()
        {
            foreach (var livro in livros)
            {
                Console.WriteLine($"Título: {livro.Titulo}, Autor: {livro.Autor}, Ano: {livro.Ano}, Prateleira: {livro.Prateleira}");
            }
        }

        static void MostrarLivrosMaisNovosQueAno()
        {
            Console.Write("Digite o ano: ");
            int ano = int.Parse(Console.ReadLine());

            var livrosMaisNovos = livros.Where(l => l.Ano > ano);

            foreach (var livro in livrosMaisNovos)
            {
                Console.WriteLine($"Título: {livro.Titulo}, Autor: {livro.Autor}, Ano: {livro.Ano}, Prateleira: {livro.Prateleira}");
            }
        }

        static void SalvarDados()
        {
            using (StreamWriter writer = new StreamWriter(caminhoArquivo))
            {
                foreach (var livro in livros)
                {
                    writer.WriteLine($"{livro.Titulo};{livro.Autor};{livro.Ano};{livro.Prateleira}");
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
                        var dados = linha.Split(';');
                        if (dados.Length == 4)
                        {
                            Livro livro = new Livro(dados[0], dados[1], int.Parse(dados[2]), dados[3]);
                            livros.Add(livro);
                        }
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
