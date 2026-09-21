using System;
using System.Collections.Generic;

public class PedidoRepository : IPedidoRepository
{
    private List<Pedido> listaDePedidos = new List<Pedido>();


    public void AddPedido(Pedido pedido)
    {
        listaDePedidos.Add(pedido);
    }

    public void RmvPedido(Pedido pedido)
    {
        listaDePedidos.Remove(pedido);
    }

    public Pedido BuscarPedido(int id)
    {
        Pedido encontrado = null;
        foreach (Pedido pedido in listaDePedidos)
        {
            if (pedido.Id == id)
            {
                encontrado = pedido;
                break;
            }
        }
        return encontrado;
    }
}