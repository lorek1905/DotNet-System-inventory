using System;

public class PedidoServices
{
    private IPedidoRepository pedidoRepository;
    public PedidoServices(IPedidoRepository pedidoRepository)
    {
        this.pedidoRepository = pedidoRepository;
    }

    public void AdicionarPedido(Pedido pedido)
    {
        pedidoRepository.AddPedido(pedido);
    }

    public void RemoverPedido(Pedido pedido)
    {
        pedidoRepository.RmvPedido(pedido);
    }

    public Pedido BuscarPedido(int id)
    {
        return pedidoRepository.BuscarPedido(id);
    }
}