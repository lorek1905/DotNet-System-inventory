using System;

public interface IPedidoRepository
{
    void AddPedido(Pedido pedido);

    void RmvPedido(Pedido pedido);

    public Pedido BuscarPedido(int id);
}