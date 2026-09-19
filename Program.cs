using System;
using System.Collections.Generic;

public class Program
{
    static void Main(String[] args)
    {
        int opcao;
        do
        {

            Console.WriteLine("===== Produtos =====");
            Console.WriteLine();
            Console.WriteLine("1 - Adicinoar produdo");
            Console.WriteLine("2 - Listar produtos");
            Console.WriteLine("3 - Remover produto");
            Console.WriteLine("4 - Buscar produto");
            Console.WriteLine("5 - Alterar estoque");
            Console.WriteLine("6 Sair");

            while (!int.TryParse(Console.ReadLine(), out opcao) || opcao > 6 || opcao < 1)
            {
                Console.WriteLine("Valor invalido! Digite novamente.");
            }


            switch (opcao)
            {
                case 1:
                    AddProduto();
                    break;
                case 2:
                    ListarProdt();
                    break;
                case 3:
                    RmvProduto();
                    break;
                case 4:
                    BuscarProduto();
                    break;
                case 5:
                    /*AlterarEstoque();*/
                    break;
                case 6:
                    Console.WriteLine("Programa encerrado");
                    break;
            }

        } while (opcao != 6);
    }

    static ProdutoServices produtoServices = new ProdutoServices();

    static void AddProduto()
    {


        Console.WriteLine("Digite o nome do produto: ");
        string nome = Console.ReadLine();
        do
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Nome invalido, digite novamente");
                nome = Console.ReadLine();
            }
        } while (string.IsNullOrWhiteSpace(nome));

        Produto existe = produtoServices.BuscarPorNome(nome);

        if (existe == null)
        {
            Console.WriteLine("Digite a quantidade em estoque");
            int quant;
            while (!int.TryParse(Console.ReadLine(), out quant) || quant < 0)
            {
                Console.Write("Valor inválido! Digite apenas números inteiros: ");
            }


            Console.WriteLine("Digite o valor do produto: ");
            decimal valor;
            while (!decimal.TryParse(Console.ReadLine(), out valor) || valor < 0)
            {
                Console.WriteLine("Valor invalido! Digite novamente");
            }

            Produto novoProduto = new Produto(nome, quant, valor);

            produtoServices.AdicinoarProdutos(novoProduto);

        }
        else
        {
            Console.WriteLine("Produto já existe em cadastro!");
        }
    }

    static void RmvProduto()
    {
        Console.WriteLine("Digite o nome do produto que deseja remover:");
        string nome = Console.ReadLine();

        Produto encontrado = produtoServices.BuscarPorNome(nome);


        if (encontrado != null)
        {
            MostrarProduto(encontrado);
            Console.WriteLine("Deseja remover este produto? ");
            Console.WriteLine();
            Console.WriteLine("1 - sim");
            Console.WriteLine("2 - não");



            int escolha;
            while (!int.TryParse(Console.ReadLine(), out escolha) || escolha > 2 || escolha < 1)
            {
                Console.WriteLine("Valor invalido! Digite novamente");
            }
            produtoServices.RemoverProduto(encontrado);

            if (escolha == 1)
            {
                produtoServices.RemoverProduto(encontrado);
                Console.WriteLine("Produto removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Operação cancelada.");
            }
        }
        else
        {
            Console.WriteLine("ERRO - PRODUTO NÃO REGISTRADO");
        }
    }

    static void MostrarProduto(Produto produto)
    {
        Console.WriteLine();
        Console.WriteLine($"Produto: {produto.Nome}");
        Console.WriteLine($"Quant. em estoque: {produto.Estoque}");
        Console.WriteLine($"Valor: {produto.Valor}");
        Console.WriteLine();
    }

    static void ListarProdt()
    {
        foreach (Produto produto in produtoServices.ListarProdutos())
        {
            MostrarProduto(produto);
        }

    }

    static void BuscarProduto()
    {

        Console.WriteLine("Digite o nome do produto que deseja buscar:");
        string nome = Console.ReadLine();

        Produto encontrado = produtoServices.BuscarPorNome(nome);

        if (encontrado == null)
        {
            Console.WriteLine("Produto não encontrado");
        }
        else
        {
            Console.WriteLine($"Produto: {encontrado.Nome}");
            Console.WriteLine($"Quant. em estoque: {encontrado.Estoque}");
            Console.WriteLine($"Valor: {encontrado.Valor}");
            Console.WriteLine();
        }


    }

    /*
        static void AlterarEstoque()
        {
            Console.WriteLine("Digite o nome do produto que deseja alterar: ");
            string nome = Console.ReadLine();
            Produto produto = BuscarPorNome(nome);

            MostrarProduto(produto);

            if (produto == null)
            {
                Console.WriteLine("ERRO - Produto não encontrado!");
            }
            else
            {
                Console.WriteLine("Qual operação deseja fazer?");
                Console.WriteLine("1 - Adicionar quantidade ");
                Console.WriteLine("2 - Remover quantidade");
                int escolha;
                while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > 2)
                {
                    Console.WriteLine("Escolha invalida!");

                    Console.WriteLine("Qual operação deseja fazer?");
                    Console.WriteLine("1 - Adicionar quantidade ");
                    Console.WriteLine("2 - Remover quantidade");
                }

                if (escolha == 1)
                {
                    Console.WriteLine("Digite a quantidade que deseja adicionar: ");
                    int quant;

                    while (!int.TryParse(Console.ReadLine(), out quant) || quant < 0)
                    {
                        Console.WriteLine("Valor invalido! Digite novamente");
                    }
                    produto.Estoque += quant;

                    Console.WriteLine($"Quantidade adicionada! Estoque atual: {produto.Estoque}");
                }
                else
                {
                    Console.WriteLine("Digite a quantidade que deseja remover: ");
                    int quant;

                    while (!int.TryParse(Console.ReadLine(), out quant) || quant > produto.Estoque || quant < 0)
                    {
                        Console.WriteLine("Valor invelido! Digite novamente");
                    }
                    produto.Estoque -= quant;

                    Console.WriteLine($"Quantidade removida! Estoque atual: {produto.Estoque}");
                }

            }
        }
    */
}