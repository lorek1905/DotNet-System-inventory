using System;
using System.Collections.Generic;

public class ProdutoServices
{
    private List<Produto> ListaDeProdutos = new List<Produto>();

    public Produto BuscarPorNome(string nome)
    {
        Produto produtoEncontrado = null;

        foreach (Produto produto in ListaDeProdutos)
        {
            if (nome == produto.Nome)
            {
                produtoEncontrado = produto;
                break;
            }
        }

        return produtoEncontrado;
    }

    public void AdicinoarProdutos()
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

        Produto existe = BuscarPorNome(nome);

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

            ListaDeProdutos.Add(novoProduto);
        }
        else
        {
            Console.WriteLine("Produto já cadastrado.");
        }

    }

    public void ListarProdutos()
    {
        foreach (Produto produto in ListaDeProdutos)
        {
            MostrarProduto(produto);
        }
    }

    public void RemoverProduto()
    {

        Console.WriteLine("Digite o nome do produto que deseja remover:");
        string nome = Console.ReadLine();

        Produto encontrado = BuscarPorNome(nome);


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
            if (escolha == 1)
            {
                ListaDeProdutos.Remove(encontrado);
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

    public void MostrarProduto(Produto produto)
    {
        Console.WriteLine();
        Console.WriteLine($"Produto: {produto.Nome}");
        Console.WriteLine($"Quant. em estoque: {produto.Estoque}");
        Console.WriteLine($"Valor: {produto.Valor}");
        Console.WriteLine();
    }

    public void BuscarProduto()
    {

        Console.WriteLine("Digite o nome do produto que deseja buscar:");
        string nome = Console.ReadLine();

        Produto encontrado = BuscarPorNome(nome);

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



}