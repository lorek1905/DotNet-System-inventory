using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class ProgramClient
{
    static ClientRepository clientRepository = new ClientRepository();
    static ClientServices clientServices = new ClientServices(clientRepository);

    public static void TestarCadastro()
    {
        CadastrarCliente();
    }

    static void CadastrarCliente()
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
            if (string.IsNullOrWhiteSpace(email) || !clientServices.EmailValido(email))
            {
                Console.WriteLine("Email invalido! Digite novamente:");
                email = Console.ReadLine();
            }
        } while (string.IsNullOrWhiteSpace(email) || !clientServices.EmailValido(email));


        Console.WriteLine("Digite a idade do cliente: ");
        int idade;
        while (!int.TryParse(Console.ReadLine(), out idade) || idade < 18 || idade > 120)
        {
            Console.WriteLine("Idade invalida, digite novamente: ");
        }

        Console.WriteLine("Digite o telefone do cliente: ");
        string telefone = Console.ReadLine();
        do
        {
            if (string.IsNullOrWhiteSpace(telefone) || !clientServices.TelefoneValido(telefone))
            {
                Console.WriteLine("Telefone invalido! Digite novamente:");
                telefone = Console.ReadLine();
            }
        } while (string.IsNullOrWhiteSpace(telefone) || !clientServices.TelefoneValido(telefone));

        Client novoCliente = new Client(nome, email, idade, telefone);

        bool clientExiste = clientServices.AdiconarCliente(novoCliente);

        if (clientExiste == false)
        {
            Console.WriteLine("Cliente cadastrado com sucesso!");
        }
        else
        {
            Console.WriteLine("ERRO - EMAIL JÁ REGISTRADO.");
        }

    }

    static void RemoverCliente()
    {
        Console.WriteLine("Digite o E-mail do cliente que deseja remover: ");
        string email = Console.ReadLine();
        do
        {
            if (!clientServices.EmailValido(email))
            {
                Console.WriteLine("E-mail invalido, digite novamente: ");
                email = Console.ReadLine();
            }
        } while (!clientServices.EmailValido(email));

        Client client = clientServices.BuscarCliente(email);

        if (client == null)
        {
            Console.WriteLine("E-MAIL NÃO CADASTRADO!");
        }
        else
        {
            Console.WriteLine("Tem certeza desta operação?");
            Console.WriteLine("1 - SIM");
            Console.WriteLine("2 - NÃO");
            int opcao;

            while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 2)
            {
                Console.WriteLine("Opção invalida! Digite novamente: ");
            }

            switch (opcao)
            {
                case 1:
                    clientServices.RemoverCliente(client);
                    break;
                case 2:
                    Console.WriteLine("Operação cancelada!");
                    break;
            }
        }
    }

    static void ListarClientes()
    {
        foreach (Client client in clientServices.ListarCliente())
        {
            MostrarCliente(client);
        }
    }

    static void AlterarEmail()
    {
        Console.WriteLine("Digite o E-mail do cliente: ");
        string email = Console.ReadLine();
        do
        {
            if (!clientServices.EmailValido(email))
            {
                Console.WriteLine("E-mail Invalido, digite novamente: ");
                email = Console.ReadLine();
            }
        } while (!clientServices.EmailValido(email));

        Client client = clientServices.BuscarCliente(email);

        if (client == null)
        {
            Console.WriteLine("E-MAIL NÃO CADASTRADO!");
        }
        else
        {
            MostrarCliente(client);

            Console.WriteLine($"Deseja modificar este e-mail: {email}?");
            Console.WriteLine("1 - SIM");
            Console.WriteLine("2 - NÃO");

            int opcao;
            while (int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 2)
            {
                Console.WriteLine("Valor invalido! Digite novamente:");
            }

            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Digite o novo e-mail:");

                    string novoEmail = Console.ReadLine();
                    do
                    {
                        if (!clientServices.EmailValido(novoEmail))
                        {
                            Console.WriteLine("E-mail Invalido, digite novamente: ");
                            novoEmail = Console.ReadLine();
                        }
                    } while (!clientServices.EmailValido(novoEmail));

                    clientServices.AlterarEmail(client, novoEmail);

                    break;
                case 2:
                    Console.WriteLine("Operação cancelada!");
                    break;
            }

        }

    }
    static void AlterarTel()
    {
        Console.WriteLine("Digite o E-mail do cliente: ");
        string email = Console.ReadLine();
        do
        {
            if (!clientServices.EmailValido(email))
            {
                Console.WriteLine("E-mail Invalido, digite novamente: ");
                email = Console.ReadLine();
            }
        } while (!clientServices.EmailValido(email));

        Client client = clientServices.BuscarCliente(email);

        if (client == null)
        {
            Console.WriteLine("E-MAIL NÃO CADASTRADO!");
        }
        else
        {
            MostrarCliente(client);

            Console.WriteLine($"Deseja modificar este telefone: {client.Telefone}?");
            Console.WriteLine("1 - SIM");
            Console.WriteLine("2 - NÃO");

            int opcao;
            while (int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 2)
            {
                Console.WriteLine("Valor invalido! Digite novamente:");
            }

            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Digite o novo telefone:");

                    string novoTel = Console.ReadLine();
                    do
                    {
                        Console.WriteLine("Telefone invalido, digite novamente:");
                        novoTel = Console.ReadLine();

                    } while (!clientServices.TelefoneValido(novoTel));

                    clientServices.AlterarTel(client, novoTel);

                    break;
                case 2:
                    Console.WriteLine("Operação cancelada!");
                    break;
            }

        }
    }
    static void MostrarCliente(Client client)
    {
        Console.WriteLine();
        Console.WriteLine($"Nome: {client.Nome}");
        Console.WriteLine($"Idade: {client.Idade}");
        Console.WriteLine($"Tel.: {client.Telefone}");
        Console.WriteLine($"E-mail: {client.EMail}");
    }

}