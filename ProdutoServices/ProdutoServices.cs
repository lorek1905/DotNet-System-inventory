using System;
using System.Collections.Generic;

public class ProdutoServices
{
    static ProdutoRepository produtoRepository = new ProdutoRepository();



    public IReadOnlyList<Produto> ListarProdutos()
    {
        return produtoRepository.Listar();
    }

    public Produto BuscarPorNome(string nome)
    {
        return produtoRepository.Buscar(nome);
    }

    public void AdicionarProdutos(Produto novoProduto)
    {
        produtoRepository.Adicionar(novoProduto);
    }

    public void RemoverProduto(Produto produto)
    {
        produtoRepository.Remover(produto);
    }

    public void AlterarEstoque(Produto produto, int quant)
    {
        produtoRepository.AlteracaoEstoque(produto, quant);
    }





}