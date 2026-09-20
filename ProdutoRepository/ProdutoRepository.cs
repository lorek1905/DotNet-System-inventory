
using System;
using System.Collections.Generic;

public class ProdutoRepository : IProdutoRepositoriy
{
    private List<Produto> ListaDeProdutos = new List<Produto>();

    public IReadOnlyList<Produto> Listar() //IReadOnlyList --> permite que eu mostre o conteudo da lista, mas que não possa altera-lá !!!!MUITO UTIL!!!!
    {
        return ListaDeProdutos;
    }

    public void Adicionar(Produto produto)
    {
        ListaDeProdutos.Add(produto);
    }

    public void Remover(Produto produto)
    {
        ListaDeProdutos.Remove(produto);
    }

    public Produto Buscar(string nome)
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

    public void AlteracaoEstoque(Produto produto, int quant)
    {
        produto.Estoque += quant;
    }

}

