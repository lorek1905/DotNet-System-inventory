using System.Collections.Generic;
using System;

public interface IProdutoRepositoriy //aqui a gente não usa public class, usamos interface
{
    IReadOnlyList<Produto> Listar();

    void Adicionar(Produto produto);

    void Remover(Produto produto);

    Produto Buscar(string nome);

    void AlteracaoEstoque(Produto produto, int quant);
}