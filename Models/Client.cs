public class Client
{
    public string Nome { get; set; }

    public string EMail { get; set; }

    public int Idade { get; set; }

    public int Telefone { get; set; }


    public Client(string nome, string email, int idade, int telefone)
    {
        Nome = nome;
        EMail = email;
        Idade = idade;
        Telefone = telefone;
    }
}