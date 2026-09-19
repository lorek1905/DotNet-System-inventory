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






}