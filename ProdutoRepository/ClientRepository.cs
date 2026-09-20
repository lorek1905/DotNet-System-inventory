using System;
using System.Collections.Generic;

public class ClientRepository : IClientRepository
{
    private List<Client> ListaDeClientes = new List<Client>();

    public void AddCliente(Client client)
    {
        ListaDeClientes.Add(client);
    }

    public void RmvClient(Client client)
    {
        ListaDeClientes.Remove(client);
    }

    public IReadOnlyList<Client> Listar()
    {
        return ListaDeClientes;
    }

    public Client BuscarCliente(string email)
    {
        Client encontrado = null;
        foreach (Client client in ListaDeClientes)
        {
            if (client.EMail == email)
            {
                encontrado = client;
                return encontrado;
            }
        }

        return encontrado;
    }

}