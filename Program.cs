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
                    produtoServices.AdicinoarProdutos();
                    break;
                case 2:
                    produtoServices.ListarProdutos();
                    break;
                case 3:
                    produtoServices.RemoverProduto();
                    break;
                case 4:
                    produtoServices.BuscarProduto();
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