public class Pedido
{
    public int Id { get; set; }
    public string NomeCliente { get; set; }
    public decimal ValorTotal { get; set; }

    public Pedido(int id, string nomeCliente, decimal valorTotal)
    {
        Id = id;
        NomeCliente = nomeCliente;
        ValorTotal = valorTotal;
    }
}