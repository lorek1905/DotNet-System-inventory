using System;
using System.Collections.Generic;

public class ProdutoServices
{
    private List<Produto> ListaDeProdutos = new List<Produto>();

    public List<Produto> ListarProdutos()
    {
        return ListaDeProdutos;
    }

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

    public void AdicinoarProdutos(Produto novoProduto)
    {
        ListaDeProdutos.Add(novoProduto);
    }



    public void RemoverProduto(Produto produto)
    {
        ListaDeProdutos.Remove(produto);
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