using System;
using System.Collections.Generic;

class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public double Preco { get; set; }

    public Produto(int id, string nome, double preco)
    {
        Id = id;
        Nome = nome;
        Preco = preco;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Nome: {Nome}, Preço: {Preco:C}";
    }
}

class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }

    public Cliente(int id, string nome, string email)
    {
        Id = id;
        Nome = nome;
        Email = email;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Nome: {Nome}, Email: {Email}";
    }
}

class Pedido
{
    public int Id { get; set; }
    public Cliente Cliente { get; set; }
    public DateTime Data { get; set; }
    public List<Produto> Produtos { get; set; }

    public Pedido(int id, Cliente cliente, DateTime data, List<Produto> produtos)
    {
        Id = id;
        Cliente = cliente;
        Data = data;
        Produtos = produtos;
    }

    public double CalcularTotal()
    {
        double total = 0;
        foreach (var produto in Produtos)
        {
            total += produto.Preco;
        }
        return total;
    }

    public override string ToString()
    {
        string produtosStr = string.Join(", ", Produtos);
        return $"Id do Pedido: {Id}, Cliente: {Cliente.Nome}, Data: {Data.ToShortDateString()}, Total: {CalcularTotal():C}\nProdutos: {produtosStr}";
    }
}

class Program
{
    static void Main()
    {
        // Criando produtos
        Produto produto1 = new Produto(1, "Camiseta", 29.99);
        Produto produto2 = new Produto(2, "Calça", 49.99);
        Produto produto3 = new Produto(3, "Tênis", 79.99);

        // Criando cliente
        Cliente cliente1 = new Cliente(1, "João", "joao@email.com");

        // Criando pedido
        List<Produto> produtosDoPedido = new List<Produto> { produto1, produto3 };
        Pedido pedido1 = new Pedido(1, cliente1, DateTime.Now, produtosDoPedido);

        // Exibindo informações do pedido
        Console.WriteLine(pedido1);

        // Aguarda o usuário pressionar qualquer tecla para encerrar o programa
        Console.ReadKey();
    }
}
