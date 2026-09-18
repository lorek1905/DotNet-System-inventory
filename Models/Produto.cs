public class Produto
{
    public string Nome { get; set; }
    public int Estoque { get; set; }
    public decimal Valor { get; set; }

    public Produto(string nome, int estoque, decimal valor)
    {
        Nome = nome;
        Estoque = estoque;
        Valor = valor;
    }
}