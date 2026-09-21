using System;
using System.Collections.Generic;

public class ProgramPedido
{
    static void Main()
    {

    }

    static PedidoRepository pedidoRepository = new PedidoRepository();
    static PedidoServices pedidoServices = new PedidoServices(pedidoRepository);
}