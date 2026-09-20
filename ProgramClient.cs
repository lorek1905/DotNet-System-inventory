using System;
using System.Collections.Generic;
using System.Reflection;

public class ProgramClient
{
    static ClientRepository clientRepository = new ClientRepository();
    static ClientServices clientServices = new ClientServices(clientRepository);


    public void Cadartrar()
    {
        Console.WriteLine("Digite o nome do cliente");
        string nome = Console.ReadLine();
        do
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Nome invalido, digite novamente:");
                nome = Console.ReadLine();
            }
        } while (string.IsNullOrWhiteSpace(nome));

        Console.WriteLine("Digite o E-mail:");
        string email = Console.ReadLine();

        do
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Email invalido! Digite novamente:");
                email = Console.ReadLine();
            }
        } while (string.IsNullOrWhiteSpace(email));

        Client client = clientServices.BuscarCliente(email);

        if (client != null)
        {
            Console.WriteLine("Cliente já existe em cadastro!");
        }
        else
        {
            Console.WriteLine("Digite a idade do cliente: ");
            int idade;
            while (!int.TryParse(Console.ReadLine(), out idade) || idade < 18 || idade > 120)
            {
                Console.WriteLine("Idade invalida, digite novamente: ");
            }

            Console.WriteLine("Digite o telefone do cliente: ");
            int telefone;
            while (!int.TryParse(Console.ReadLine(), out telefone))
            {
                Console.WriteLine("telefone invalido, digite novamente: ");
            }

            Client novoCliente = new Client(nome, email, idade, telefone);
            clientServices.AdiconarCliente(novoCliente);
        }


    }

    public void RemoverCliente()
    {

    }

    public void ListarClientes()
    {

    }



}