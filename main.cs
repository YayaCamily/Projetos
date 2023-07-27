using System;

// Definição da classe Pessoa
class Pessoa
{
    // Propriedades da classe
    public string Nome { get; set; }
    public int Idade { get; set; }

    // Método para exibir informações da pessoa
    public void ExibirInformacoes()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Idade: {Idade} anos");
    }
}

class Program
{
    static void Main()
    {
        // Criando um objeto da classe Pessoa
        Pessoa pessoa1 = new Pessoa();

        // Definindo os valores das propriedades do objeto pessoa1
        pessoa1.Nome = "João";
        pessoa1.Idade = 30;

        // Exibindo as informações da pessoa1
        Console.WriteLine("Informações da Pessoa 1:");
        pessoa1.ExibirInformacoes();

        // Criando outro objeto da classe Pessoa
        Pessoa pessoa2 = new Pessoa();

        // Definindo os valores das propriedades do objeto pessoa2
        pessoa2.Nome = "Maria";
        pessoa2.Idade = 25;

        // Exibindo as informações da pessoa2
        Console.WriteLine("\nInformações da Pessoa 2:");
        pessoa2.ExibirInformacoes();
    }
}
