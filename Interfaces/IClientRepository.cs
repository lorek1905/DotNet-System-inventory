using System;
using System.Collections.Generic;

public interface IClientRepository
{
    void AddCliente(Client client);

    void RmvClient(Client client);

    public IReadOnlyList<Client> Listar();

    public Client BuscarCliente(string email);
}