using System;
using System.Collections.Generic;

public class ProgramPedido
{
    static void B()
    {

    }

    static PedidoRepository pedidoRepository = new PedidoRepository();
    static PedidoServices pedidoServices = new PedidoServices(pedidoRepository);
}