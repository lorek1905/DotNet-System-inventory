using System;
using System.Collections.Generic;

public class ClientServices
{
    private IClientRepository clientRepository; //chama o contrto
    public ClientServices(IClientRepository clientRepository) //construtor, que aceira o parametro repository
    {
        this.clientRepository = clientRepository;
    }
    public void AdiconarCliente(Client client)
    {
        clientRepository.AddCliente(client);
    }

    public void RemoverCliente(Client client)
    {
        clientRepository.RmvClient(client);
    }

    public IReadOnlyList<Client> ListarCliente()
    {
        return clientRepository.Listar();
    }

    public Client BuscarCliente(string email)
    {
        return clientRepository.BuscarCliente(email);
    }
}