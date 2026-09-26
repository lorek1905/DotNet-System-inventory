using System;
using System.Collections.Generic;

public class ProdutoServices
{
    private IProdutoRepositoriy produtoRepository;

    public ProdutoServices(IProdutoRepositoriy produtoRepository)//construtor
    {
        this.produtoRepository = produtoRepository;
    }

    public IReadOnlyList<Produto> ListarProdutos()
    {
        return produtoRepository.Listar();
    }

    public Produto BuscarPorNome(string nome)
    {
        return produtoRepository.Buscar(nome);
    }

    public bool AdicionarProdutos(Produto novoProduto)
    {
        bool existe = false;

        Produto produdo = BuscarPorNome(novoProduto.Nome);
        if (produdo == null)
        {
            produtoRepository.Adicionar(novoProduto);
            return existe;
        }
        else
        {
            return existe = true;
        }
    }

    public void RemoverProduto(Produto produto)
    {
        produtoRepository.Remover(produto);
    }

    public bool AlterarEstoque(Produto produto, int quant)
    {
        if (produto.Estoque + quant < 0)
        {
            return false;
        }
        produtoRepository.AlteracaoEstoque(produto, quant);
        return true;
    }

}