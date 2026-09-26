using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class ClientServices
{
    private IClientRepository clientRepository; //chama o contrto
    public ClientServices(IClientRepository clientRepository) //construtor, que aceira o parametro repository
    {
        this.clientRepository = clientRepository;
    }
    public bool AdiconarCliente(Client client)
    {
        Client verificarExiste = BuscarCliente(client.EMail);

        if (verificarExiste == null)
        {
            clientRepository.AddCliente(client);
            return false;
        }

        return true;


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

    public void AlterarEmail(Client client, string novoEmail)
    {
        clientRepository.AlterarEmail(client, novoEmail);
    }

    public void AlterarTel(Client client, string novoTel)
    {
        clientRepository.AlterarEmail(client, novoTel);
    }


    public bool EmailValido(string email)
    {
        string formato = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, formato);
    }

    public bool TelefoneValido(string telefone)
    {
        return Regex.IsMatch(telefone, @"^\d{11}$");
    }

}